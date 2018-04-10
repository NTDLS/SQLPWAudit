using System;
using SQLPWAudit.Forms;

namespace SQLPWAudit
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            FormMain formMain = new FormMain();
            formMain.ShowDialog();
        }
    }
}
