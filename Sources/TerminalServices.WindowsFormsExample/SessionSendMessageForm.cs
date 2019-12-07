using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    public partial class SessionSendMessageForm : Form
    {
        public SessionSendMessageForm()
        {
            InitializeComponent();

            this.buttons.Items.AddRange(GetValues(typeof(SessionMessageBoxButtons)));
            this.icon.Items.AddRange(GetValues(typeof(SessionMessageBoxIcon)));
            this.defaultButtons.Items.AddRange(GetValues(typeof(SessionMessageBoxDefaultButton)));

            this.buttons.SelectedIndex = 0;
            this.icon.SelectedIndex = 0;
            this.defaultButtons.SelectedIndex = 0;
        }

        private static object[] GetValues(Type enumType)
        {
            Array temp;
            object[] result;

            temp = Enum.GetValues(enumType);
            result = new object[temp.Length];
            Array.Copy(temp, result, temp.Length);

            return result;
        }

        public static SessionMessageBoxResult SendMessage(MainForm mainForm, Session session)
        {
            using (SessionSendMessageForm f = new SessionSendMessageForm())
            {
                if (f.ShowDialog(mainForm) == DialogResult.OK)
                {
                    return session.SendMessage(f.message.Text, f.waitUserSessionAnswer.Checked, f.title.Text,
                        (SessionMessageBoxButtons)f.buttons.SelectedItem,
                        (SessionMessageBoxIcon)f.icon.SelectedItem,
                        (SessionMessageBoxDefaultButton)f.defaultButtons.SelectedItem);
                }

                return SessionMessageBoxResult.None;
            }
        }
    }
}
