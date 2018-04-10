namespace SQLPWAudit.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdStartStop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtConsumedWords = new System.Windows.Forms.Label();
            this.lblConsumedWords = new System.Windows.Forms.Label();
            this.txtCurrentWord = new System.Windows.Forms.Label();
            this.txtCompletedChunks = new System.Windows.Forms.Label();
            this.txtPermutations = new System.Windows.Forms.Label();
            this.lblActiveThreads = new System.Windows.Forms.Label();
            this.lblCompletedChunks = new System.Windows.Forms.Label();
            this.lblCurrentWord = new System.Windows.Forms.Label();
            this.lblPermutations = new System.Windows.Forms.Label();
            this.txtActiveThreads = new System.Windows.Forms.Label();
            this.dgvNativeUsers = new System.Windows.Forms.DataGridView();
            this.ColumnServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNativeUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdClear);
            this.splitContainer1.Panel1.Controls.Add(this.cmdExport);
            this.splitContainer1.Panel1.Controls.Add(this.cmdAbout);
            this.splitContainer1.Panel1.Controls.Add(this.cmdStartStop);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvNativeUsers);
            this.splitContainer1.Size = new System.Drawing.Size(344, 392);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(257, 96);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 3;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(257, 67);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 2;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(257, 38);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(75, 23);
            this.cmdAbout.TabIndex = 1;
            this.cmdAbout.Text = "About";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdStartStop
            // 
            this.cmdStartStop.Location = new System.Drawing.Point(257, 9);
            this.cmdStartStop.Name = "cmdStartStop";
            this.cmdStartStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStartStop.TabIndex = 0;
            this.cmdStartStop.Text = "Start";
            this.cmdStartStop.UseVisualStyleBackColor = true;
            this.cmdStartStop.Click += new System.EventHandler(this.cmdStartStop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtConsumedWords);
            this.groupBox3.Controls.Add(this.lblConsumedWords);
            this.groupBox3.Controls.Add(this.txtCurrentWord);
            this.groupBox3.Controls.Add(this.txtCompletedChunks);
            this.groupBox3.Controls.Add(this.txtPermutations);
            this.groupBox3.Controls.Add(this.lblActiveThreads);
            this.groupBox3.Controls.Add(this.lblCompletedChunks);
            this.groupBox3.Controls.Add(this.lblCurrentWord);
            this.groupBox3.Controls.Add(this.lblPermutations);
            this.groupBox3.Controls.Add(this.txtActiveThreads);
            this.groupBox3.Location = new System.Drawing.Point(12, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 116);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Workload State";
            // 
            // txtConsumedWords
            // 
            this.txtConsumedWords.AutoSize = true;
            this.txtConsumedWords.Location = new System.Drawing.Point(119, 34);
            this.txtConsumedWords.Name = "txtConsumedWords";
            this.txtConsumedWords.Size = new System.Drawing.Size(73, 13);
            this.txtConsumedWords.TabIndex = 10;
            this.txtConsumedWords.Text = "<Not Started>";
            // 
            // lblConsumedWords
            // 
            this.lblConsumedWords.AutoSize = true;
            this.lblConsumedWords.Location = new System.Drawing.Point(22, 34);
            this.lblConsumedWords.Name = "lblConsumedWords";
            this.lblConsumedWords.Size = new System.Drawing.Size(91, 13);
            this.lblConsumedWords.TabIndex = 9;
            this.lblConsumedWords.Text = "Consumed Words";
            // 
            // txtCurrentWord
            // 
            this.txtCurrentWord.AutoSize = true;
            this.txtCurrentWord.Location = new System.Drawing.Point(119, 16);
            this.txtCurrentWord.Name = "txtCurrentWord";
            this.txtCurrentWord.Size = new System.Drawing.Size(73, 13);
            this.txtCurrentWord.TabIndex = 2;
            this.txtCurrentWord.Text = "<Not Started>";
            // 
            // txtCompletedChunks
            // 
            this.txtCompletedChunks.AutoSize = true;
            this.txtCompletedChunks.Location = new System.Drawing.Point(119, 88);
            this.txtCompletedChunks.Name = "txtCompletedChunks";
            this.txtCompletedChunks.Size = new System.Drawing.Size(73, 13);
            this.txtCompletedChunks.TabIndex = 8;
            this.txtCompletedChunks.Text = "<Not Started>";
            // 
            // txtPermutations
            // 
            this.txtPermutations.AutoSize = true;
            this.txtPermutations.Location = new System.Drawing.Point(119, 52);
            this.txtPermutations.Name = "txtPermutations";
            this.txtPermutations.Size = new System.Drawing.Size(73, 13);
            this.txtPermutations.TabIndex = 3;
            this.txtPermutations.Text = "<Not Started>";
            // 
            // lblActiveThreads
            // 
            this.lblActiveThreads.AutoSize = true;
            this.lblActiveThreads.Location = new System.Drawing.Point(34, 70);
            this.lblActiveThreads.Name = "lblActiveThreads";
            this.lblActiveThreads.Size = new System.Drawing.Size(79, 13);
            this.lblActiveThreads.TabIndex = 5;
            this.lblActiveThreads.Text = "Active Threads";
            // 
            // lblCompletedChunks
            // 
            this.lblCompletedChunks.AutoSize = true;
            this.lblCompletedChunks.Location = new System.Drawing.Point(14, 88);
            this.lblCompletedChunks.Name = "lblCompletedChunks";
            this.lblCompletedChunks.Size = new System.Drawing.Size(99, 13);
            this.lblCompletedChunks.TabIndex = 7;
            this.lblCompletedChunks.Text = "Completed Threads";
            // 
            // lblCurrentWord
            // 
            this.lblCurrentWord.AutoSize = true;
            this.lblCurrentWord.Location = new System.Drawing.Point(43, 16);
            this.lblCurrentWord.Name = "lblCurrentWord";
            this.lblCurrentWord.Size = new System.Drawing.Size(70, 13);
            this.lblCurrentWord.TabIndex = 1;
            this.lblCurrentWord.Text = "Current Word";
            // 
            // lblPermutations
            // 
            this.lblPermutations.AutoSize = true;
            this.lblPermutations.Location = new System.Drawing.Point(45, 52);
            this.lblPermutations.Name = "lblPermutations";
            this.lblPermutations.Size = new System.Drawing.Size(68, 13);
            this.lblPermutations.TabIndex = 4;
            this.lblPermutations.Text = "Permutations";
            // 
            // txtActiveThreads
            // 
            this.txtActiveThreads.AutoSize = true;
            this.txtActiveThreads.Location = new System.Drawing.Point(119, 70);
            this.txtActiveThreads.Name = "txtActiveThreads";
            this.txtActiveThreads.Size = new System.Drawing.Size(73, 13);
            this.txtActiveThreads.TabIndex = 6;
            this.txtActiveThreads.Text = "<Not Started>";
            // 
            // dgvNativeUsers
            // 
            this.dgvNativeUsers.AllowUserToAddRows = false;
            this.dgvNativeUsers.AllowUserToDeleteRows = false;
            this.dgvNativeUsers.AllowUserToResizeRows = false;
            this.dgvNativeUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNativeUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServer,
            this.ColumnUsername,
            this.ColumnPassword});
            this.dgvNativeUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNativeUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvNativeUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvNativeUsers.Name = "dgvNativeUsers";
            this.dgvNativeUsers.RowHeadersVisible = false;
            this.dgvNativeUsers.Size = new System.Drawing.Size(344, 264);
            this.dgvNativeUsers.TabIndex = 0;
            // 
            // ColumnServer
            // 
            this.ColumnServer.HeaderText = "Server";
            this.ColumnServer.Name = "ColumnServer";
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
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 392);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 430);
            this.Name = "FormMain";
            this.Text = "SQL Password Audit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNativeUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvNativeUsers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdStartStop;
        private System.Windows.Forms.Label txtCurrentWord;
        private System.Windows.Forms.Label lblCurrentWord;
        private System.Windows.Forms.Label lblPermutations;
        private System.Windows.Forms.Label txtPermutations;
        private System.Windows.Forms.Label txtActiveThreads;
        private System.Windows.Forms.Label lblActiveThreads;
        private System.Windows.Forms.Label txtCompletedChunks;
        private System.Windows.Forms.Label lblCompletedChunks;
        private System.Windows.Forms.Label txtConsumedWords;
        private System.Windows.Forms.Label lblConsumedWords;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdExport;
    }
}