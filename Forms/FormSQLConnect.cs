using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SQLPWAudit.Forms
{
    public partial class FormSQLConnect : Form
    {
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

        private bool _RequireAdmin = true;
        private string _RegistrySubKey = null;
        public SQLConnectionInfo ConnectionInfo = new SQLConnectionInfo();

        #region Constructors / Destructors.

        public FormSQLConnect()
        {
            InitializeComponent();
            _RequireAdmin = false;
            _RegistrySubKey = "Default";
        }

        public FormSQLConnect(bool requireAdmin)
        {
            InitializeComponent();
            _RequireAdmin = requireAdmin;
            _RegistrySubKey = "Default";
        }

        public FormSQLConnect(string registrySubKey, bool requireAdmin)
        {
            InitializeComponent();
            _RequireAdmin = requireAdmin;
            _RegistrySubKey = registrySubKey;
        }

        public FormSQLConnect(string registrySubKey)
        {
            InitializeComponent();
            _RequireAdmin = false;
            _RegistrySubKey = registrySubKey;
        }

        #endregion

        private void SQLConnectForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = cmdOk;
            this.CancelButton = cmdCancel;

            LoadFromRegistry();
        }

        private void LoadFromRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(this.RegistryKey, false);
                if (regKey == null) //Key doesnt exist?
                {
                    Registry.CurrentUser.CreateSubKey(this.RegistryKey); //Create the key.
                    regKey = Registry.CurrentUser.OpenSubKey(this.RegistryKey, false); //Reopen the key.
                }

                if (regKey != null)
                {
                    cboServerName.Text = regKey.GetValue("Servername", "(local)").ToString();
                    txtUsername.Text = regKey.GetValue("Username", "").ToString();
                    txtPassword.Text = regKey.GetValue("Password", "").ToString();
                    cbIntegratedSecurity.Checked = CBool(regKey.GetValue("IntegratedSecurity", true));
                }
                else
                {
                    cboServerName.Text = "(local)";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
            }
            catch { }
        }

        private void SaveToRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(this.RegistryKey, true);
                if (regKey == null) //Key doesnt exist?
                {
                    Registry.CurrentUser.CreateSubKey(this.RegistryKey); //Create the key.
                    regKey = Registry.CurrentUser.OpenSubKey(this.RegistryKey, true); //Reopen the key.
                }

                if (regKey != null)
                {
                    regKey.SetValue("Servername", cboServerName.Text);
                    regKey.SetValue("Username", txtUsername.Text);
                    regKey.SetValue("Password", txtPassword.Text);
                    regKey.SetValue("IntegratedSecurity", cbIntegratedSecurity.Checked);
                }
            }
            catch { }
        }

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

                    if (_RequireAdmin)
                    {
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
                                throw new Exception("SQL server role could not be determined.");
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
                    }
                    else
                    {
                        allowConnection = true;
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

        private void cmdOk_Click(object sender, EventArgs e)
        {
            ConnectionInfo.Username = txtUsername.Text;
            ConnectionInfo.Password = txtPassword.Text;
            ConnectionInfo.ServerName = cboServerName.Text;
            ConnectionInfo.UseIntegratedSecurity = cbIntegratedSecurity.Checked;

            if (CheckConnectivity())
            {
                SaveToRegistry();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        #region Public Mehtods.

        public string RegistryKey
        {
            get { return "Software\\" + Application.CompanyName + "\\" + Application.ProductName + "\\Connectivity\\" + _RegistrySubKey; }
        }

        public string Caption
        {
            get { return this.Text.Trim(); }
            set { this.Text = value.Trim(); }
        }

        #endregion
    }
}
