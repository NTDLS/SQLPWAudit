namespace SQLPWAudit.Forms
{
    partial class FormAbout
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApplication = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.LinkLabel();
            this.txtBuild = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.Label();
            this.txtCopyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(327, 121);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(56, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 7);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application:";
            // 
            // txtApplication
            // 
            this.txtApplication.AutoSize = true;
            this.txtApplication.Location = new System.Drawing.Point(125, 12);
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(77, 13);
            this.txtApplication.TabIndex = 3;
            this.txtApplication.Text = "XXXXXXXXXX";
            // 
            // txtWebsite
            // 
            this.txtWebsite.AutoSize = true;
            this.txtWebsite.Location = new System.Drawing.Point(125, 62);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(118, 13);
            this.txtWebsite.TabIndex = 4;
            this.txtWebsite.TabStop = true;
            this.txtWebsite.Text = "www.NetworkDLS.com";
            this.txtWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtWebsite_LinkClicked);
            // 
            // txtBuild
            // 
            this.txtBuild.AutoSize = true;
            this.txtBuild.Location = new System.Drawing.Point(125, 46);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Size = new System.Drawing.Size(77, 13);
            this.txtBuild.TabIndex = 5;
            this.txtBuild.Text = "XXXXXXXXXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Build:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Website:";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(32, 32);
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.Location = new System.Drawing.Point(125, 29);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(77, 13);
            this.txtVersion.TabIndex = 10;
            this.txtVersion.Text = "XXXXXXXXXX";
            // 
            // txtCopyright
            // 
            this.txtCopyright.AutoSize = true;
            this.txtCopyright.Location = new System.Drawing.Point(63, 86);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(246, 13);
            this.txtCopyright.TabIndex = 11;
            this.txtCopyright.Text = "Copyright © 1776 NetworkDLS. All rights reserved.";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 157);
            this.Controls.Add(this.txtCopyright);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuild);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.txtApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NetworkDLS";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtApplication;
        private System.Windows.Forms.LinkLabel txtWebsite;
        private System.Windows.Forms.Label txtBuild;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.Label txtCopyright;
    }
}