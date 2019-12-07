using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    public partial class MainForm : Form
    {
        private Server server;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnShown(object sender, EventArgs e)
        {
            string serverName;

            serverName = ServerNameForm.AskServerName(this);
            if (serverName == null)
                Application.Exit();
            else
            {
                this.server = Server.Connect(serverName);

                this.RefreshSessions();
                this.RefreshProcesses();
            }
        }

        private void RefreshSessions()
        {
            this.server.RefreshSessions();

            foreach (Session session in this.server.Sessions)
            {
                SessionListViewItem temp;

                temp = this.FindSession(session);
                if (temp != null)
                    temp.Refresh();
                else
                    this.sessions.Items.Add(new SessionListViewItem(session));
            }

            //Remove processes that don't exist.
            foreach (SessionListViewItem session in this.sessions.Items)
            {
                if (this.server.Sessions.Contains(session.Session) == false)
                    session.Remove();
            }
        }
        private SessionListViewItem FindSession(Session session)
        {
            foreach (SessionListViewItem s in this.sessions.Items)
            {
                if (session == s.Session)
                    return s;
            }

            return null;
        }

        private void RefreshProcesses()
        {
            this.server.RefreshProcesses();

            foreach (Process process in this.server.Processes)
            {
                ProcessListViewItem temp;

                temp = this.FindProcess(process);
                if (temp == null)
                    this.processes.Items.Add(new ProcessListViewItem(process));
            }

            //Remove processes that don't exist.
            foreach (ProcessListViewItem process in this.processes.Items)
            {
                if (this.server.Processes.Contains(process.Process) == false)
                    process.Remove();
            }
        }
        private ProcessListViewItem FindProcess(Process process)
        {
            foreach (ProcessListViewItem p in this.processes.Items)
            {
                if (process == p.Process)
                    return p;
            }

            return null;
        }

        private void OnRefreshSessionClick(object sender, EventArgs e)
        {
            foreach (SessionListViewItem session in this.sessions.SelectedItems)
                session.Refresh();
        }
        private void OnDisconnectSessionClick(object sender, EventArgs e)
        {
            foreach (SessionListViewItem session in this.sessions.SelectedItems)
            {
                session.Session.Disconnect();
                session.Refresh();
            }
        }
        private void OnLogoffSessionClick(object sender, EventArgs e)
        {
            foreach (SessionListViewItem session in this.sessions.SelectedItems)
                session.Session.Logoff();

            this.RefreshSessions();
        }
        private void OnSessionSendMessageClick(object sender, EventArgs e)
        {
            SessionMessageBoxResult result;

            result = SessionSendMessageForm.SendMessage(this, 
                ((SessionListViewItem)this.sessions.SelectedItems[0]).Session);

            MessageBox.Show("The user has press the " + result + " button");
        }

        private void OnSessionsMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                DisplayContextMenu(this.sessions, this.sessionContextMenu, e.Location);
        }

        private static void DisplayContextMenu(ListView listView, ContextMenuStrip contextMenu, Point location)
        {
            ListViewHitTestInfo hitTest;

            hitTest = listView.HitTest(location);
            if (listView.SelectedItems.Contains(hitTest.Item) == true)
                contextMenu.Show(listView, location);
        }

        private void OnTerminateProcessClick(object sender, EventArgs e)
        {
            ((ProcessListViewItem)this.processes.SelectedItems[0]).Process.Terminate(0);
            this.RefreshProcesses();
        }
        private void OnProcessesMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                DisplayContextMenu(this.processes, this.processContextMenu, e.Location);
        }

        private void OnRefreshSessionsClick(object sender, EventArgs e)
        {
            this.RefreshSessions();
        }

        private void OnRefreshProcessClick(object sender, EventArgs e)
        {
            this.RefreshProcesses();
        }

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                    components = null;
                }

                if (this.server != null)
                {
                    this.server.Dispose();
                    this.server = null;
                }
            }
            base.Dispose(disposing);
        }

        

        

       

    }
}
