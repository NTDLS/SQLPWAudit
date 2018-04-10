using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SQLPWAudit.Classes;

namespace SQLPWAudit.Forms
{
    public partial class FormLoad : Form
    {
        private TabPage _CurrentTab;
        CSQLWParallelizer.SettingParams _SettingParams;

        public FormLoad()
        {
            InitializeComponent();

        }

        public FormLoad(ref CSQLWParallelizer.SettingParams settingParams)
        {
            InitializeComponent();
            _SettingParams = settingParams;
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            tabSetup.SelectedIndexChanged += new EventHandler(tabSetup_SelectedIndexChanged);
            tbPermutationComplexity_ValueChanged(null, null);

            cboServerName.Text = "(local)";
            txtChunkSize.Text = "1000";
            this.AcceptButton = cmdNext;
            txtThreads.Text = Environment.ProcessorCount.ToString();

            if (_SettingParams != null && _SettingParams.HaveParametersBeenLoaded)
            {
                cboServerName.Text = _SettingParams.Servername;
                txtWordList.Text = _SettingParams.WordList;
                txtThreads.Text = _SettingParams.ThreadCount.ToString();
                tbPermutationComplexity.Value = _SettingParams.PermutationComplexity;
                cbAppendNumbers.Checked = _SettingParams.AppendNumbers;
                txtChunkSize.Text = _SettingParams.ChunkSize.ToString();
                txtUsername.Text = _SettingParams.Username;
                txtPassword.Text = _SettingParams.Password;
                cbIntegratedSecurity.Checked = _SettingParams.IntegratedSecurity;
                cbAppendNumbers.Checked = _SettingParams.AppendNumbers;

                if (_SettingParams.WordList.Length > 0)
                {
                    PopulateWordListPreview(_SettingParams.WordList);
                }
            }
        }

        private void tabSetup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeTab();
        }

        void ChangeTab()
        {
            tabSetup.SelectedTab = _CurrentTab;

            if (_CurrentTab ==  tabSQLServer)
            {
                cboServerName.Focus();
            }         

            if (_CurrentTab == tabSettings)
            {
                cmdNext.Text = "Start!";
            }
            else
            {
                cmdNext.Text = "Next >";
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            //Validate current tabs:

            if (_CurrentTab == tabSQLServer)
            {
                if (cboServerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter a SQL Server name / IP Address.");
                    return;
                }

                ConnectionInfo.Username = txtUsername.Text;
                ConnectionInfo.Password = txtPassword.Text;
                ConnectionInfo.ServerName = cboServerName.Text;
                ConnectionInfo.UseIntegratedSecurity = cbIntegratedSecurity.Checked;

                if (CheckConnectivity())
                {
                    _CurrentTab = tabSQLServerUsers;
                    PopulateUsersFromNativeLogins();

                }
                else
                {
                    //Failed to connect to SQL Server.
                }
            }
            else if (_CurrentTab == tabSQLServerUsers)
            {
                _SettingParams.SQLUsers = new List<CSQLWParallelizer.SQLUser>();
                foreach (DataGridViewRow row in dgvNativeUsers.Rows)
                {
                    DataGridViewCheckBoxCell cell = ((DataGridViewCheckBoxCell)row.Cells["ColumnAudit"]);
                    if (cell != null && cell.Value != DBNull.Value && (int)cell.Value == 1)
                    {
                        _SettingParams.SQLUsers.Add(new CSQLWParallelizer.SQLUser(row.Cells["ColumnUsername"].Value.ToString(), (byte[])row.Cells["ColumnPassword"].Value));
                    }
                }

                _CurrentTab = tabWordList;
            }
            else if (_CurrentTab == tabWordList)
            {
                if (txtWordList.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter a word list file name.");
                    return;
                }

                _CurrentTab = tabSettings;
            }
            else if (_CurrentTab == tabSettings)
            {
                _SettingParams.ChunkSize = int.Parse(txtChunkSize.Text);
                _SettingParams.ThreadCount = int.Parse(txtThreads.Text);
                _SettingParams.WordList = txtWordList.Text;
                _SettingParams.PermutationComplexity = tbPermutationComplexity.Value;
                _SettingParams.AppendNumbers = cbAppendNumbers.Checked;
                _SettingParams.Servername = cboServerName.Text;
                _SettingParams.Username = txtUsername.Text;
                _SettingParams.Password = txtPassword.Text;
                _SettingParams.IntegratedSecurity = cbIntegratedSecurity.Checked;
                _SettingParams.HaveParametersBeenLoaded = true;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            ChangeTab();
        }
      
        private void cmdBrowseWordList_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Select a password list";
            ofd.DefaultExt = ".txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtWordList.Text = ofd.FileName;
                PopulateWordListPreview(ofd.FileName);
            }
        }

        void PopulateWordListPreview(string fileName)
        {
            try
            {
                StreamReader streamReader = new StreamReader(fileName);
                string word = string.Empty;

                dgvWordListPreview.Rows.Clear();

                for (int i = 0; i < 100 && (word = streamReader.ReadLine()) != null; i++)
                {
                    dgvWordListPreview.Rows.Add(word);
                }

                streamReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void PopulateUsersFromNativeLogins()
        {
            System.Text.StringBuilder tSQL = new StringBuilder();
            tSQL.AppendLine("SELECT");
            tSQL.AppendLine("   1 AS Audit,");
            tSQL.AppendLine("   name AS Username,");
            tSQL.AppendLine("   convert(varbinary(30), [password]) as Password");
            tSQL.AppendLine("FROM");
            tSQL.AppendLine("   sys.syslogins");
            tSQL.AppendLine("WHERE");
            tSQL.AppendLine("   isntname = 0");
            tSQL.AppendLine("   AND isntgroup = 0");
            tSQL.AppendLine("   AND hasaccess = 1");
            tSQL.AppendLine("   AND name not like '##%'");
            tSQL.AppendLine("ORDER BY");
            tSQL.AppendLine("   name");

            using (SqlConnection connection = new SqlConnection(ConnectionInfo.ConnectionString))
            {
                connection.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(tSQL.ToString(), connection);
                adapter.SelectCommand.CommandText = tSQL.ToString();
                adapter.Fill(ds, "SQLLogins");

                dgvNativeUsers.AutoGenerateColumns = false;
                dgvNativeUsers.DataSource = ds;
                dgvNativeUsers.DataMember = "SQLLogins";

                dgvNativeUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                connection.Close();
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            if (_CurrentTab == tabSettings)
            {
                _CurrentTab = tabWordList;
            }
            else if (_CurrentTab == tabWordList)
            {
                _CurrentTab = tabSQLServerUsers;
            }
            else if (_CurrentTab == tabSQLServerUsers)
            {
                _CurrentTab = tabSQLServer;
            }

            ChangeTab();
        }

        #region SQL Server Connectivity
        #region Custom Types.

        public class SQLConnectionInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string ServerName { get; set; }
            public bool UseIntegratedSecurity { get; set; }

            public string ConnectionString
            {
                get
                {
                    System.Text.StringBuilder connectionString = new System.Text.StringBuilder();

                    connectionString.Append("server=" + this.ServerName + ";");
                    connectionString.Append("app=" + Application.ProductName + " " + Application.ProductVersion + ";");

                    if (this.UseIntegratedSecurity)
                    {
                        connectionString.Append("trusted_connection=yes;");
                    }
                    else
                    {
                        connectionString.Append("uid=" + this.Username + ";");
                        connectionString.Append("pwd=" + this.Password + ";");
                    }

                    return connectionString.ToString();
                }
            }
        }

        private class SQLServerListObject
        {
            private string ServerName { get; set; }
            private string InstanceName { get; set; }
            private string Version { get; set; }
            private bool IsClustered { get; set; }

            #region Constructors.
            public SQLServerListObject(string serverName)
            {
                this.ServerName = serverName;
            }
            public SQLServerListObject(string serverName, string instanceName)
            {
                this.ServerName = serverName;
                this.InstanceName = instanceName;
            }
            public SQLServerListObject(string serverName, string instanceName, string version)
            {
                this.ServerName = serverName;
                this.InstanceName = instanceName;
                this.Version = version;
            }
            public SQLServerListObject(string serverName, string instanceName, string version, bool isClustered)
            {
                this.ServerName = serverName;
                this.InstanceName = instanceName;
                this.Version = version;
                this.IsClustered = isClustered;
            }
            #endregion

            #region Properties.
            public override string ToString()
            {
                return this.ServerName;
            }

            #endregion
        }

        struct ThreadParams
        {
            public delegate void deAddSQLServerToComboBox(SQLServerListObject sqlObject);
            public deAddSQLServerToComboBox AddSQLServerToComboBox;
            public Form OwnerForm;
            public FormProgress FormProgress;
        }

        #endregion

        public SQLConnectionInfo ConnectionInfo = new SQLConnectionInfo();

        private bool CBool(object value)
        {
            string sValue = value.ToString().ToUpper();

            Int32 iResult;
            if (Int32.TryParse(sValue, out iResult))
            {
                return (iResult != 0);
            }
            else
            {
                switch (sValue)
                {
                    case "YES":
                        return true;
                    case "TRUE":
                        return true;
                    case "ON":
                        return true;
                }
            }

            return false;
        }

        private bool CheckConnectivity()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionInfo.ConnectionString))
            {
                try
                {
                    bool allowConnection = false;
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT IS_SRVROLEMEMBER('sysadmin')", sqlConnection);
                    SqlDataReader sqlReader = null;

                    try
                    {
                        sqlReader = sqlCommand.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            allowConnection = CBool(sqlReader[0]);
                        }
                        else
                        {
                            MessageBox.Show("SQL server role could not be determined.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (sqlReader != null)
                        {
                            sqlReader.Close();
                        }
                    }

                    return allowConnection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }
            }

            return false;
        }

        private void AddSQLServerToComboBox(SQLServerListObject sqlObject)
        {
            cboServerName.Items.Add(sqlObject);
        }

        private void ParameterizedThread(object obj)
        {
            System.Threading.Thread.Sleep(500);

            Int32 rowIndex = 0;

            ThreadParams threadParams = (ThreadParams)obj;
            FormProgress.delCloseForm deCloseForm = threadParams.FormProgress.CloseForm;
            FormProgress.delSetBodyText deSetBodyText = threadParams.FormProgress.SetBodyText;
            FormProgress.delSetProgressMaximum deSetProgressMaximum = threadParams.FormProgress.SetProgressMaximum;
            FormProgress.delSetProgressPosition deSetProgressPosition = threadParams.FormProgress.SetProgressPosition;

            //threadParams.FormProgress.Invoke(deSetBodyText, "Waiting on network...");

            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();

            threadParams.FormProgress.Invoke(deSetBodyText, "Populating " + table.Rows.Count + " servers...");
            threadParams.FormProgress.Invoke(deSetProgressMaximum, table.Rows.Count);

            foreach (System.Data.DataRow row in table.Rows)
            {
                SQLServerListObject sqlObject = new SQLServerListObject(row["ServerName"].ToString(),
                    row["InstanceName"].ToString(), row["Version"].ToString(), CBool(row["isClustered"]));

                threadParams.OwnerForm.Invoke(threadParams.AddSQLServerToComboBox, sqlObject);

                threadParams.FormProgress.Invoke(deSetProgressPosition, rowIndex++);
                System.Threading.Thread.Sleep(10);
            }

            threadParams.FormProgress.Invoke(deCloseForm);
        }

        private void cboServername_DropDown(object sender, EventArgs e)
        {
            if (cboServerName.Items.Count == 0)
            {
                FormProgress FormProgress = new FormProgress();

                System.Threading.Thread thread = new System.Threading.Thread(ParameterizedThread);

                ThreadParams threadParams = new ThreadParams();
                threadParams.OwnerForm = this;
                threadParams.FormProgress = FormProgress;
                threadParams.AddSQLServerToComboBox = AddSQLServerToComboBox;

                thread.Start(threadParams);

                FormProgress.EnableCancel(true);

                if (FormProgress.ShowDialog() != DialogResult.OK)
                {
                    if (thread.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        thread.Abort();
                    }
                }
            }
        }

        private void cbIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !cbIntegratedSecurity.Checked;
            txtPassword.Enabled = !cbIntegratedSecurity.Checked;
        }

        #endregion

        private void FormLoad_Shown(object sender, EventArgs e)
        {
            _CurrentTab = tabSQLServer;
            ChangeTab();
        }

        void PopulateComplexityPreview()
        {
            List<string> words = CSQLWParallelizer.ApplyMutationRules("Platitudinous", tbPermutationComplexity.Value, cbAppendNumbers.Checked);

            dgvComplexityPreview.Rows.Clear();

            foreach (string word in words)
            {
                dgvComplexityPreview.Rows.Add(word);
            }

            dgvComplexityPreview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            lblDistinctWords.Text = "Distinct Words: " + dgvComplexityPreview.Rows.Count.ToString("#,#");
        }

        private void cbAppendNumbers_CheckedChanged(object sender, EventArgs e)
        {
            PopulateComplexityPreview();
        }
        
        private void tbPermutationComplexity_ValueChanged(object sender, EventArgs e)
        {
            PopulateComplexityPreview();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cmdSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNativeUsers.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["ColumnAudit"]).Value = true;
            }
        }

        private void cmdDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNativeUsers.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["ColumnAudit"]).Value = false;
            }
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
    }
}
