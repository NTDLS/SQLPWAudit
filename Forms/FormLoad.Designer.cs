namespace SQLPWAudit.Forms
{
    partial class FormLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoad));
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabSQLServerUsers = new System.Windows.Forms.TabPage();
            this.cmdDeselectAll = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.dgvNativeUsers = new System.Windows.Forms.DataGridView();
            this.ColumnAudit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSQLServer = new System.Windows.Forms.TabPage();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.cboServerName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabSetup = new System.Windows.Forms.TabControl();
            this.tabWordList = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvWordListPreview = new System.Windows.Forms.DataGridView();
            this.columnWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBrowseWordList = new System.Windows.Forms.Button();
            this.txtWordList = new System.Windows.Forms.TextBox();
            this.lblWordList = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDistinctWords = new System.Windows.Forms.Label();
            this.dgvComplexityPreview = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAppendNumbers = new System.Windows.Forms.CheckBox();
            this.tbPermutationComplexity = new System.Windows.Forms.TrackBar();
            this.lblChunkSize = new System.Windows.Forms.Label();
            this.txtChunkSize = new System.Windows.Forms.TextBox();
            this.lblThreads = new System.Windows.Forms.Label();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.tabSQLServerUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNativeUsers)).BeginInit();
            this.tabSQLServer.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabWordList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordListPreview)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplexityPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPermutationComplexity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNext
            // 
            this.cmdNext.AutoSize = true;
            this.cmdNext.Location = new System.Drawing.Point(387, 295);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 1;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(306, 295);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 2;
            this.cmdBack.Text = "< Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(12, 295);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tabSQLServerUsers
            // 
            this.tabSQLServerUsers.Controls.Add(this.cmdDeselectAll);
            this.tabSQLServerUsers.Controls.Add(this.cmdSelectAll);
            this.tabSQLServerUsers.Controls.Add(this.dgvNativeUsers);
            this.tabSQLServerUsers.Location = new System.Drawing.Point(4, 22);
            this.tabSQLServerUsers.Name = "tabSQLServerUsers";
            this.tabSQLServerUsers.Size = new System.Drawing.Size(446, 251);
            this.tabSQLServerUsers.TabIndex = 2;
            this.tabSQLServerUsers.Text = "SQL Server Users";
            this.tabSQLServerUsers.UseVisualStyleBackColor = true;
            // 
            // cmdDeselectAll
            // 
            this.cmdDeselectAll.Location = new System.Drawing.Point(84, 225);
            this.cmdDeselectAll.Name = "cmdDeselectAll";
            this.cmdDeselectAll.Size = new System.Drawing.Size(75, 23);
            this.cmdDeselectAll.TabIndex = 2;
            this.cmdDeselectAll.Text = "Deselect All";
            this.cmdDeselectAll.UseVisualStyleBackColor = true;
            this.cmdDeselectAll.Click += new System.EventHandler(this.cmdDeselectAll_Click);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(3, 225);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectAll.TabIndex = 1;
            this.cmdSelectAll.Text = "Select All";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // dgvNativeUsers
            // 
            this.dgvNativeUsers.AllowUserToAddRows = false;
            this.dgvNativeUsers.AllowUserToDeleteRows = false;
            this.dgvNativeUsers.AllowUserToResizeRows = false;
            this.dgvNativeUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNativeUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAudit,
            this.ColumnUsername,
            this.ColumnPassword});
            this.dgvNativeUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvNativeUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvNativeUsers.Name = "dgvNativeUsers";
            this.dgvNativeUsers.RowHeadersVisible = false;
            this.dgvNativeUsers.Size = new System.Drawing.Size(446, 219);
            this.dgvNativeUsers.TabIndex = 0;
            // 
            // ColumnAudit
            // 
            this.ColumnAudit.DataPropertyName = "Audit";
            this.ColumnAudit.HeaderText = "Audit";
            this.ColumnAudit.Name = "ColumnAudit";
            this.ColumnAudit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAudit.Width = 35;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.DataPropertyName = "Username";
            this.ColumnUsername.HeaderText = "Username";
            this.ColumnUsername.Name = "ColumnUsername";
            this.ColumnUsername.ReadOnly = true;
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.DataPropertyName = "Password";
            this.ColumnPassword.HeaderText = "Password";
            this.ColumnPassword.Name = "ColumnPassword";
            this.ColumnPassword.ReadOnly = true;
            this.ColumnPassword.Visible = false;
            // 
            // tabSQLServer
            // 
            this.tabSQLServer.Controls.Add(this.txtUsername);
            this.tabSQLServer.Controls.Add(this.txtPassword);
            this.tabSQLServer.Controls.Add(this.label3);
            this.tabSQLServer.Controls.Add(this.cbIntegratedSecurity);
            this.tabSQLServer.Controls.Add(this.cboServerName);
            this.tabSQLServer.Controls.Add(this.label4);
            this.tabSQLServer.Controls.Add(this.label5);
            this.tabSQLServer.Location = new System.Drawing.Point(4, 22);
            this.tabSQLServer.Name = "tabSQLServer";
            this.tabSQLServer.Size = new System.Drawing.Size(446, 251);
            this.tabSQLServer.TabIndex = 4;
            this.tabSQLServer.Text = "SQL Server";
            this.tabSQLServer.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(130, 105);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(130, 144);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server Name:";
            // 
            // cbIntegratedSecurity
            // 
            this.cbIntegratedSecurity.AutoSize = true;
            this.cbIntegratedSecurity.Checked = true;
            this.cbIntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIntegratedSecurity.Location = new System.Drawing.Point(130, 170);
            this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
            this.cbIntegratedSecurity.Size = new System.Drawing.Size(143, 17);
            this.cbIntegratedSecurity.TabIndex = 6;
            this.cbIntegratedSecurity.Text = "Use Integrated Security?";
            this.cbIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbIntegratedSecurity_CheckedChanged);
            // 
            // cboServerName
            // 
            this.cboServerName.FormattingEnabled = true;
            this.cboServerName.Location = new System.Drawing.Point(130, 57);
            this.cboServerName.Name = "cboServerName";
            this.cboServerName.Size = new System.Drawing.Size(192, 21);
            this.cboServerName.TabIndex = 1;
            this.cboServerName.DropDown += new System.EventHandler(this.cboServername_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.tabSQLServer);
            this.tabSetup.Controls.Add(this.tabSQLServerUsers);
            this.tabSetup.Controls.Add(this.tabWordList);
            this.tabSetup.Controls.Add(this.tabSettings);
            this.tabSetup.Location = new System.Drawing.Point(12, 12);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.SelectedIndex = 0;
            this.tabSetup.Size = new System.Drawing.Size(454, 277);
            this.tabSetup.TabIndex = 0;
            // 
            // tabWordList
            // 
            this.tabWordList.Controls.Add(this.label1);
            this.tabWordList.Controls.Add(this.dgvWordListPreview);
            this.tabWordList.Controls.Add(this.cmdBrowseWordList);
            this.tabWordList.Controls.Add(this.txtWordList);
            this.tabWordList.Controls.Add(this.lblWordList);
            this.tabWordList.Location = new System.Drawing.Point(4, 22);
            this.tabWordList.Name = "tabWordList";
            this.tabWordList.Size = new System.Drawing.Size(446, 251);
            this.tabWordList.TabIndex = 5;
            this.tabWordList.Text = "Word List";
            this.tabWordList.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Word List Preview";
            // 
            // dgvWordListPreview
            // 
            this.dgvWordListPreview.AllowUserToAddRows = false;
            this.dgvWordListPreview.AllowUserToDeleteRows = false;
            this.dgvWordListPreview.AllowUserToResizeRows = false;
            this.dgvWordListPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWordListPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnWord});
            this.dgvWordListPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvWordListPreview.Location = new System.Drawing.Point(13, 85);
            this.dgvWordListPreview.Name = "dgvWordListPreview";
            this.dgvWordListPreview.RowHeadersVisible = false;
            this.dgvWordListPreview.Size = new System.Drawing.Size(423, 150);
            this.dgvWordListPreview.TabIndex = 4;
            // 
            // columnWord
            // 
            this.columnWord.DataPropertyName = "Word";
            this.columnWord.HeaderText = "Word";
            this.columnWord.Name = "columnWord";
            this.columnWord.ReadOnly = true;
            // 
            // cmdBrowseWordList
            // 
            this.cmdBrowseWordList.Location = new System.Drawing.Point(364, 35);
            this.cmdBrowseWordList.Name = "cmdBrowseWordList";
            this.cmdBrowseWordList.Size = new System.Drawing.Size(72, 23);
            this.cmdBrowseWordList.TabIndex = 2;
            this.cmdBrowseWordList.Text = "Browse";
            this.cmdBrowseWordList.UseVisualStyleBackColor = true;
            this.cmdBrowseWordList.Click += new System.EventHandler(this.cmdBrowseWordList_Click);
            // 
            // txtWordList
            // 
            this.txtWordList.Location = new System.Drawing.Point(13, 37);
            this.txtWordList.Name = "txtWordList";
            this.txtWordList.ReadOnly = true;
            this.txtWordList.Size = new System.Drawing.Size(345, 20);
            this.txtWordList.TabIndex = 1;
            // 
            // lblWordList
            // 
            this.lblWordList.AutoSize = true;
            this.lblWordList.Location = new System.Drawing.Point(10, 19);
            this.lblWordList.Name = "lblWordList";
            this.lblWordList.Size = new System.Drawing.Size(52, 13);
            this.lblWordList.TabIndex = 0;
            this.lblWordList.Text = "Word List";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.cbAppendNumbers);
            this.tabSettings.Controls.Add(this.tbPermutationComplexity);
            this.tabSettings.Controls.Add(this.lblChunkSize);
            this.tabSettings.Controls.Add(this.txtChunkSize);
            this.tabSettings.Controls.Add(this.lblThreads);
            this.tabSettings.Controls.Add(this.txtThreads);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(446, 251);
            this.tabSettings.TabIndex = 6;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Complexity Permutations";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDistinctWords);
            this.groupBox1.Controls.Add(this.dgvComplexityPreview);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(240, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 233);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Workload Preview";
            // 
            // lblDistinctWords
            // 
            this.lblDistinctWords.AutoSize = true;
            this.lblDistinctWords.Location = new System.Drawing.Point(6, 211);
            this.lblDistinctWords.Name = "lblDistinctWords";
            this.lblDistinctWords.Size = new System.Drawing.Size(88, 13);
            this.lblDistinctWords.TabIndex = 2;
            this.lblDistinctWords.Text = "Distinct Words: 0";
            // 
            // dgvComplexityPreview
            // 
            this.dgvComplexityPreview.AllowUserToAddRows = false;
            this.dgvComplexityPreview.AllowUserToDeleteRows = false;
            this.dgvComplexityPreview.AllowUserToResizeRows = false;
            this.dgvComplexityPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplexityPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvComplexityPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvComplexityPreview.Location = new System.Drawing.Point(9, 56);
            this.dgvComplexityPreview.Name = "dgvComplexityPreview";
            this.dgvComplexityPreview.RowHeadersVisible = false;
            this.dgvComplexityPreview.Size = new System.Drawing.Size(179, 152);
            this.dgvComplexityPreview.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn1.HeaderText = "Word";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "Based on your settings, the word \"Platitudinous\" becomes:";
            // 
            // cbAppendNumbers
            // 
            this.cbAppendNumbers.AutoSize = true;
            this.cbAppendNumbers.Location = new System.Drawing.Point(17, 220);
            this.cbAppendNumbers.Name = "cbAppendNumbers";
            this.cbAppendNumbers.Size = new System.Drawing.Size(163, 17);
            this.cbAppendNumbers.TabIndex = 6;
            this.cbAppendNumbers.Text = "Append sequential numbers?";
            this.cbAppendNumbers.UseVisualStyleBackColor = true;
            this.cbAppendNumbers.CheckedChanged += new System.EventHandler(this.cbAppendNumbers_CheckedChanged);
            // 
            // tbPermutationComplexity
            // 
            this.tbPermutationComplexity.Location = new System.Drawing.Point(17, 167);
            this.tbPermutationComplexity.Maximum = 4;
            this.tbPermutationComplexity.Name = "tbPermutationComplexity";
            this.tbPermutationComplexity.Size = new System.Drawing.Size(179, 45);
            this.tbPermutationComplexity.TabIndex = 5;
            this.tbPermutationComplexity.Value = 1;
            this.tbPermutationComplexity.ValueChanged += new System.EventHandler(this.tbPermutationComplexity_ValueChanged);
            // 
            // lblChunkSize
            // 
            this.lblChunkSize.AutoSize = true;
            this.lblChunkSize.Location = new System.Drawing.Point(14, 55);
            this.lblChunkSize.Name = "lblChunkSize";
            this.lblChunkSize.Size = new System.Drawing.Size(93, 13);
            this.lblChunkSize.TabIndex = 2;
            this.lblChunkSize.Text = "Words per Thread";
            // 
            // txtChunkSize
            // 
            this.txtChunkSize.Location = new System.Drawing.Point(16, 72);
            this.txtChunkSize.Name = "txtChunkSize";
            this.txtChunkSize.Size = new System.Drawing.Size(115, 20);
            this.txtChunkSize.TabIndex = 3;
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(13, 15);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(107, 13);
            this.lblThreads.TabIndex = 0;
            this.lblThreads.Text = "Threads (Concurrent)";
            // 
            // txtThreads
            // 
            this.txtThreads.Location = new System.Drawing.Point(16, 32);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(115, 20);
            this.txtThreads.TabIndex = 1;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(93, 295);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(75, 23);
            this.cmdAbout.TabIndex = 4;
            this.cmdAbout.Text = "About";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 328);
            this.Controls.Add(this.cmdAbout);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.tabSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load Users";
            this.Load += new System.EventHandler(this.FormLoad_Load);
            this.Shown += new System.EventHandler(this.FormLoad_Shown);
            this.tabSQLServerUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNativeUsers)).EndInit();
            this.tabSQLServer.ResumeLayout(false);
            this.tabSQLServer.PerformLayout();
            this.tabSetup.ResumeLayout(false);
            this.tabWordList.ResumeLayout(false);
            this.tabWordList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordListPreview)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplexityPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPermutationComplexity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabPage tabSQLServerUsers;
        private System.Windows.Forms.TabPage tabSQLServer;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbIntegratedSecurity;
        private System.Windows.Forms.ComboBox cboServerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabSetup;
        private System.Windows.Forms.DataGridView dgvNativeUsers;
        private System.Windows.Forms.TabPage tabWordList;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TrackBar tbPermutationComplexity;
        private System.Windows.Forms.Label lblChunkSize;
        private System.Windows.Forms.TextBox txtChunkSize;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.TextBox txtThreads;
        private System.Windows.Forms.Button cmdBrowseWordList;
        private System.Windows.Forms.TextBox txtWordList;
        private System.Windows.Forms.Label lblWordList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvWordListPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnWord;
        private System.Windows.Forms.DataGridView dgvComplexityPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbAppendNumbers;
        private System.Windows.Forms.Label lblDistinctWords;
        private System.Windows.Forms.Button cmdDeselectAll;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.Button cmdAbout;
    }
}