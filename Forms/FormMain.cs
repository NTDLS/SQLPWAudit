using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SQLPWAudit.Classes;
using System.IO;

namespace SQLPWAudit.Forms
{
    public partial class FormMain : Form
    {
        CSQLWParallelizer CSQLWParallelizer = new CSQLWParallelizer();
        public delReportProgress deReportProgress;
        public delUpdatePassword deUpdatePassword;
        public delStateChanged deStateChanged;

        CSQLWParallelizer.SettingParams _SettingParams = new CSQLWParallelizer.SettingParams();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            deReportProgress = ReportProgress;
            deUpdatePassword = UpdatePassword;
            deStateChanged = StateChanged;
        }

        bool ConnectAndPopulate()
        {
            FormLoad formLoad = new FormLoad(ref _SettingParams);
            if (formLoad.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return false;
            }

            this.Text = Application.ProductName + ": " + _SettingParams.Servername;

            return true;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (!ConnectAndPopulate())
            {
                this.Close();
                return;
            }

            Start();
        }

        public delegate void delReportProgress(string currentWord, int consumedWords, Int64 permutations, int activeThreads, int completedChunks);
        void ReportProgress(string currentWord, int consumedWords, Int64 permutations, int activeThreads, int completedChunks)
        {
            txtCurrentWord.Text = currentWord;
            txtPermutations.Text = permutations.ToString("#,#");
            txtActiveThreads.Text = activeThreads.ToString("#,#");
            txtCompletedChunks.Text = completedChunks.ToString("#,#");
            txtConsumedWords.Text = consumedWords.ToString("#,#");
        }

        public delegate void delUpdatePassword(string serverName, string userName, string password);
        void UpdatePassword(string serverName, string userName, string password)
        {
            string []row = new string[3];

            row[0] = serverName;
            row[1] = userName;
            row[2] = password;
            dgvNativeUsers.Rows.Add(row);

            dgvNativeUsers.Sort(dgvNativeUsers.Columns["ColumnUsername"], ListSortDirection.Ascending);
            dgvNativeUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public delegate void delStateChanged(bool isRunning);
        void StateChanged(bool isRunning)
        {
            if (isRunning)
            {
            }
            else
            {
                cmdStartStop.Text = "Start";
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CSQLWParallelizer.IsRunning)
            {
                if (MessageBox.Show("Would you like to cancel the current operation?", "Cancel the Operation?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    CSQLWParallelizer.Stop();
                }
            }
        }

        void Start()
        {
            try
            {
                CSQLWParallelizer.Start(this, _SettingParams);
                cmdStartStop.Text = "Stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem parsing your input. Error [" + ex.Message + "]");
            }
        }

        private void cmdStartStop_Click(object sender, EventArgs e)
        {
            if (cmdStartStop.Text == "Start")
            {
                if (ConnectAndPopulate())
                {
                    Start();
                }
            }
            else if (cmdStartStop.Text == "Stop")
            {
                if (MessageBox.Show("Would you like to cancel the current operation?", "Cancel the Operation?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    CSQLWParallelizer.Stop();
                    cmdStartStop.Text = "Wait..";
                }
            }
            else
            {
                //...
            }
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.CheckPathExists = true;
            sfd.CheckFileExists = false;
            sfd.Title = "Save audit results as:";
            sfd.FileName = "SQLAudit - " + DateTime.Now.ToShortDateString().Replace("\\", "-").Replace(":", "_").Replace("/", "_").Replace(".", "_");
            sfd.AddExtension = true;
            sfd.DefaultExt = ".txt";
            sfd.OverwritePrompt = true;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    string word = string.Empty;

                    streamWriter.WriteLine("Server\tUser\tPassword");

                    foreach (DataGridViewRow row in dgvNativeUsers.Rows)
                    {
                        streamWriter.WriteLine(
                            row.Cells[0].Value.ToString() + "\t" +
                            row.Cells[1].Value.ToString() + "\t" +
                            row.Cells[2].Value.ToString()
                            );
                    }

                    streamWriter.Close();
                    MessageBox.Show("The tab-delimited file has been saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all users/password from the list?", "Clear List?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                dgvNativeUsers.Rows.Clear();
            }
        }
    }
}

