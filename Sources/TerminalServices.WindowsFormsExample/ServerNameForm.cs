using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    internal partial class ServerNameForm : Form
    {
        public ServerNameForm()
        {
            InitializeComponent();
        }

        public static string AskServerName(MainForm mainForm)
        {
            using (ServerNameForm f = new ServerNameForm())
            {
                if (f.ShowDialog(mainForm) == DialogResult.OK)
                    return f.serverName.Text;

                return null;
            }
        }
    }
}
