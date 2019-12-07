using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    public class SessionListViewItem : ListViewItem
    {
        private Session session;
        private ListViewSubItem connectionState;
        private ListViewSubItem winStationName;

        public SessionListViewItem(Session session)
        {
            this.session = session;

            this.Text = session.Id.ToString();
            this.winStationName = this.SubItems.Add(session.WinStationName);
            this.connectionState = this.SubItems.Add(session.ConnectionState.ToString());
        }

        public Session Session
        {
            get { return this.session; }
        }

        public void Refresh()
        {
            this.session.Refresh();

            this.Text = session.Id.ToString();

            this.connectionState.Text = session.ConnectionState.ToString();
            this.winStationName.Text = session.WinStationName;
        }
    }
}
