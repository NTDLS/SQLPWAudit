using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SQLPWAudit.Classes
{
    public class CSQLWParallelizer
    {
        public class SettingParams
        {
            public string WordList;
            public int ThreadCount;
            public int ChunkSize;
            public int PermutationComplexity;
            public bool AppendNumbers;
            public List<CSQLWParallelizer.SQLUser> SQLUsers;
            public bool HaveParametersBeenLoaded;
            public string Servername;
            public string Username;
            public string Password;
            public bool IntegratedSecurity;
        }

        public class SQLUser
        {
            public bool PasswordFound { get; set; }
            private string _Username;
            private byte[] _PasswordHash;

            public string Username
            {
                get
                {
                    return _Username;
                }
            }

            public byte[] PasswordHash
            {
                get
                {
                    return _PasswordHash;
                }
            }

            public SQLUser(string username, byte[] PasswordHash)
            {
                _Username = username;
                _PasswordHash = PasswordHash;
                PasswordFound = false;
            }
        }

        //State:
        private List<Thread> _Threads;
        private volatile int _ActiveThreads = 0;
        private Int64 _Permutations = 0;
        private int _ConsumedWords = 0;
        private volatile int _StatusCounter = 0;
        private object _LockObject = new object();
        private int _CompletedChunks = 0;
        private bool _StopRunning = false;
        private bool _IsRunning = false;

        //Settings:
        SettingParams _SettingParams;
        Forms.FormMain _FormMain;

        public void Stop()
        {
            _StopRunning = true;

        }

        public bool IsRunning
        {
            get
            {
                return _IsRunning;
            }
        }

        public void Start(Forms.FormMain formMain, SettingParams settingParams)
        {
            //State:
            _Threads = null;
            _ActiveThreads = 0;
            _Permutations = 0;
            _CompletedChunks = 0;
            _ConsumedWords = 0;
            _StopRunning = false;
            _IsRunning = false;

            //Settings:
            _SettingParams = settingParams;
            _FormMain = formMain;
            _StopRunning = false;
            _IsRunning = true;

            _FormMain.Invoke(_FormMain.deStateChanged, true);

            ThreadPool.QueueUserWorkItem(StartAsync);
        }

        void StartAsync(object value)
        {
            _Threads = new List<Thread>(_SettingParams.ThreadCount);
            for (int i = 0; i < _SettingParams.ThreadCount; i++)
            {
                _Threads.Add(null);
            }

            string line;
            bool complete = false;
            System.IO.StreamReader file = new System.IO.StreamReader(_SettingParams.WordList);
            List<string> wordsChunk = new List<string>(_SettingParams.ChunkSize);

            _ConsumedWords++;
            wordsChunk.Add(""); //We always try a blank password.

            while (!_StopRunning && !complete)
            {
                for (int thread = 0; thread < _SettingParams.ThreadCount && !complete; thread++)
                {
                    if (_StopRunning)
                    {
                        break;
                    }
                    if (_Threads[thread] == null
                        || _Threads[thread].ThreadState == System.Threading.ThreadState.Unstarted
                        || _Threads[thread].ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        while (true)
                        {
                            if (_StopRunning)
                            {
                                break;
                            }
                            if ((line = file.ReadLine()) != null)
                            {
                                _ConsumedWords++;
                                wordsChunk.Add(line);
                            }
                            else
                            {
                                complete = true;
                            }

                            if (wordsChunk.Count == _SettingParams.ChunkSize || complete == true)
                            {
                                _Threads[thread] = new Thread(ParameterizedThread);
                                _Threads[thread].Start(wordsChunk);

                                wordsChunk = new List<string>(_SettingParams.ChunkSize);
                                lock (_LockObject)
                                {
                                    _ActiveThreads++;
                                }
                                break;
                            }
                        }
                    }

                    Thread.Sleep(10);
                }
            }

            file.Close();

            //Wait on all threads to complete.
            while (true)
            {
                int completedthreads = 0;
                for (int thread = 0; thread < _SettingParams.ThreadCount; thread++)
                {
                    if (_Threads[thread] == null
                        || _Threads[thread].ThreadState == System.Threading.ThreadState.Unstarted
                        || _Threads[thread].ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        completedthreads++;
                    }
                }

                if (completedthreads == _SettingParams.ThreadCount)
                {
                    break;
                }
            }

            if (_StopRunning)
            {
                _FormMain.Invoke(_FormMain.deReportProgress, "<Cancelled!>", _ConsumedWords, _Permutations, _ActiveThreads, _CompletedChunks);
            }
            else
            {
                _FormMain.Invoke(_FormMain.deReportProgress, "<Completed!>", _ConsumedWords, _Permutations, _ActiveThreads, _CompletedChunks);
            }

            _IsRunning = false;
            _FormMain.Invoke(_FormMain.deStateChanged, false);
        }

        public void ParameterizedThread(Object threadContext)
        {
            byte[] fullProposedPasswordHash = new byte[26];
            byte[] proposedPasswordTextBytes;
            byte[] proposedPasswordBuild;
            byte[] proposedPasswordHash;
            byte[] salt = new byte[4];
            byte[] header = { 0x01, 0x00 };
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1Managed();
            List<string> mutations = new List<string>();

            List<String> words = (List<String>)threadContext;
            foreach (var word in words)
            {
                if (_StopRunning)
                {
                    break;
                }

                if (_SettingParams.PermutationComplexity == 0)
                {
                    mutations.Clear();
                    mutations.Add(word);
                }
                else
                {
                    mutations = ApplyMutationRules(word, _SettingParams.PermutationComplexity, _SettingParams.AppendNumbers);
                }

                _Permutations += mutations.Count();

                for (int userIndex = 0; userIndex < _SettingParams.SQLUsers.Count && !_StopRunning; userIndex++)
                {
                    if (!_SettingParams.SQLUsers[userIndex].PasswordFound)
                    {
                        Buffer.BlockCopy(_SettingParams.SQLUsers[userIndex].PasswordHash, 2, salt, 0, 4);

                        foreach (string mutation in mutations)
                        {
                            proposedPasswordTextBytes = Encoding.Unicode.GetBytes(mutation);
                            proposedPasswordBuild = new byte[proposedPasswordTextBytes.Length + 4];

                            Buffer.BlockCopy(proposedPasswordTextBytes, 0, proposedPasswordBuild, 0, proposedPasswordTextBytes.Length);
                            Buffer.BlockCopy(salt, 0, proposedPasswordBuild, proposedPasswordTextBytes.Length, 4);

                            proposedPasswordHash = sha1.ComputeHash(proposedPasswordBuild);

                            Buffer.BlockCopy(header, 0, fullProposedPasswordHash, 0, 2);
                            Buffer.BlockCopy(salt, 0, fullProposedPasswordHash, 2, 4);
                            Buffer.BlockCopy(proposedPasswordHash, 0, fullProposedPasswordHash, 6, proposedPasswordHash.Length);

                            if (_StatusCounter++ > 123456)
                            {
                                _FormMain.Invoke(_FormMain.deReportProgress, mutation, _ConsumedWords, _Permutations, _ActiveThreads, _CompletedChunks);
                                _StatusCounter = 0;
                            }

                            if (fullProposedPasswordHash.SequenceEqual(_SettingParams.SQLUsers[userIndex].PasswordHash))
                            {
                                _SettingParams.SQLUsers[userIndex].PasswordFound = true;
                                _FormMain.Invoke(_FormMain.deUpdatePassword, _SettingParams.Servername, _SettingParams.SQLUsers[userIndex].Username, mutation);
                                break;
                            }
                        }
                    }
                }
            }

            lock (_LockObject)
            {
                _ActiveThreads--;
                _CompletedChunks++;
            }
        }

        public static List<string> ApplyMutationRules(string word, int permutations, bool appendNumbers)
        {
            List<string> mutations = new List<string>();
            ApplyMutationRules(ref mutations, word, permutations, appendNumbers);
            return (from w in mutations select w).Distinct().ToList();
        }

        private static void ApplyMutationRules(ref List<string> list, string word, int permutations, bool appendNumbers)
        {
            string newWord;

            if (permutations > 0)
            {
                for (int iteration = 0; iteration < (appendNumbers ? 46 : 36); iteration++)
                {
                    newWord = ApplyMutationRule(word, iteration);
                    list.Add(newWord);

                    if (permutations > 1)
                    {
                        ApplyMutationRules(ref list, newWord, permutations - 1, appendNumbers);
                    }
                }
            }
            else
            {
                list.Add(word);
            }
        }

        private static string ApplyMutationRule(string text, int iteration)
        {
            if (text == "")
            {
                return "";
            }

            switch (iteration)
            {
                case 0: return text; //Raw text.
                case 1: return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower(); //Psudo proper case.
                case 2: return text.ToUpper();
                case 3: return text.ToLower();

                case 4: return text + "?";
                case 5: return text + "!";

                case 6: return text.Replace("A", "@").Replace("a", "@");
                case 7: return text.ToUpper().Replace("A", "@");
                case 8: return text.ToLower().Replace("a", "@");

                case 9: return text.Replace("L", "1").Replace("l", "1");
                case 10: return text.ToUpper().Replace("L", "1");
                case 11: return text.ToLower().Replace("l", "1");

                case 12: return text.Replace("S", "$").Replace("s", "$");
                case 13: return text.ToUpper().Replace("S", "$");
                case 14: return text.ToLower().Replace("s", "$");

                case 15: return text.Replace("P", "9").Replace("p", "9");
                case 16: return text.ToUpper().Replace("P", "9");
                case 17: return text.ToLower().Replace("p", "9");

                case 18: return text.Replace("V", "^").Replace("v", "^");
                case 19: return text.ToUpper().Replace("V", "^");
                case 20: return text.ToLower().Replace("v", "^");

                case 21: return text.Replace("L", "!").Replace("l", "!");
                case 22: return text.ToUpper().Replace("L", "!");
                case 23: return text.ToLower().Replace("l", "!");

                case 24: return text.Replace("1", "!").Replace("1", "!");
                case 25: return text.ToUpper().Replace("1", "!");
                case 26: return text.ToLower().Replace("1", "!");

                case 27: return text.Replace("O", "0").Replace("o", "0");
                case 28: return text.ToUpper().Replace("O", "0");
                case 29: return text.ToLower().Replace("o", "0");

                case 30: return text.Replace("0", "O");
                case 31: return text.ToUpper().Replace("0", "O");
                case 32: return text.ToLower().Replace("0", "o");

                case 33: return text.Replace("E", "3").Replace("e", "3");
                case 34: return text.ToUpper().Replace("E", "3");
                case 35: return text.ToLower().Replace("e", "3");

                case 36: return text + "0";
                case 37: return text + "1";
                case 38: return text + "2";
                case 39: return text + "3";
                case 40: return text + "4";
                case 41: return text + "5";
                case 42: return text + "6";
                case 43: return text + "7";
                case 44: return text + "8";
                case 45: return text + "9";
            }
            return text;
        }

        #region Utility

        private static byte[] StringToByteArray(String hex)
        {
            if (hex.Substring(0, 2) == "0x")
            {
                hex = hex.Substring(2);
            }
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        void PrintBytes(byte[] bytes)
        {
            foreach (byte element in bytes)
            {
                Debug.WriteLine(element);
            }
        }

        #endregion
    }
}
