using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLPWAudit.Forms
{
    public partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();

            lblHeader.Text = "Please wait...";
            lblBody.Text = "";
            cmdCancel.Enabled = false;
            pbProgress.Minimum = 0;
            pbProgress.Maximum = 100;

            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region Properties.
        public string CaptionText
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string HeaderText
        {
            get { return this.lblHeader.Text; }
            set { this.lblHeader.Text = value; }
        }
        public string BodyText
        {
            get { return this.lblBody.Text; }
            set { this.lblBody.Text = value; }
        }
        public int ProgressMinimum
        {
            get { return pbProgress.Minimum; }
            set { pbProgress.Minimum = value; }
        }
        public int ProgressMaximum
        {
            get { return pbProgress.Maximum; }
            set { pbProgress.Maximum = value; }
        }
        public int ProgressPosition
        {
            get { return pbProgress.Value; }
            set { pbProgress.Value = value; }
        }
        #endregion

        #region Redundant of Properties for Delegation
        public delegate void delSetCaptionText(string value);
        public delegate void delSetHeaderText(string value);
        public delegate void delSetBodyText(string value);
        public delegate void delSetProgressMinimum(int value);
        public delegate void delSetProgressMaximum(int value);
        public delegate void delSetProgressPosition(int value);
        public delegate void delSetOwnerForm(Form OwnerForm);
        public delegate void delCloseFormWithResult(DialogResult dialogResult);
        public delegate void delCloseForm();
        public delegate void delEnableCancel(bool bEnable);

        public void CloseFormWithResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
            this.Close();
        }

        public void CloseForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void EnableCancel(bool bEnable)
        {
            this.cmdCancel.Enabled = bEnable;
        }
        public void SetOwnerForm(Form OwnerForm)
        {
            this.Owner = OwnerForm;
        }
        public void SetCaptionText(string value)
        {
            this.Text = value;
        }
        public void SetHeaderText(string value)
        {
            this.lblHeader.Text = value;
        }
        public void SetBodyText(string value)
        {
            this.lblBody.Text = value;
        }
        public void SetProgressMinimum(int value)
        {
            pbProgress.Minimum = value;
        }
        public void SetProgressMaximum(int value)
        {
            pbProgress.Maximum = value;
        }
        public void SetProgressPosition(int value)
        {
            pbProgress.Value = value;
        }
        #endregion
    }
}
