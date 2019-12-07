namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sessionsPage = new System.Windows.Forms.TabPage();
            this.sessions = new System.Windows.Forms.ListView();
            this.sessionId = new System.Windows.Forms.ColumnHeader();
            this.sessionWinStationName = new System.Windows.Forms.ColumnHeader();
            this.sessionState = new System.Windows.Forms.ColumnHeader();
            this.processesPage = new System.Windows.Forms.TabPage();
            this.processes = new System.Windows.Forms.ListView();
            this.processId = new System.Windows.Forms.ColumnHeader();
            this.processName = new System.Windows.Forms.ColumnHeader();
            this.sessionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectSession = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffSession = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSession = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionSendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.processContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSessions2 = new System.Windows.Forms.ToolStripButton();
            this.refreshProcess2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControl1.SuspendLayout();
            this.sessionsPage.SuspendLayout();
            this.processesPage.SuspendLayout();
            this.sessionContextMenu.SuspendLayout();
            this.processContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sessionsPage);
            this.tabControl1.Controls.Add(this.processesPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(609, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // sessionsPage
            // 
            this.sessionsPage.Controls.Add(this.sessions);
            this.sessionsPage.Location = new System.Drawing.Point(4, 22);
            this.sessionsPage.Name = "sessionsPage";
            this.sessionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.sessionsPage.Size = new System.Drawing.Size(601, 356);
            this.sessionsPage.TabIndex = 0;
            this.sessionsPage.Text = "Sessions";
            this.sessionsPage.UseVisualStyleBackColor = true;
            // 
            // sessions
            // 
            this.sessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sessionId,
            this.sessionWinStationName,
            this.sessionState});
            this.sessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessions.FullRowSelect = true;
            this.sessions.Location = new System.Drawing.Point(3, 3);
            this.sessions.Name = "sessions";
            this.sessions.Size = new System.Drawing.Size(595, 350);
            this.sessions.TabIndex = 0;
            this.sessions.UseCompatibleStateImageBehavior = false;
            this.sessions.View = System.Windows.Forms.View.Details;
            this.sessions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnSessionsMouseClick);
            // 
            // sessionId
            // 
            this.sessionId.Text = "ID";
            // 
            // sessionWinStationName
            // 
            this.sessionWinStationName.DisplayIndex = 2;
            this.sessionWinStationName.Text = "WinStationName";
            this.sessionWinStationName.Width = 150;
            // 
            // sessionState
            // 
            this.sessionState.DisplayIndex = 1;
            this.sessionState.Text = "State";
            this.sessionState.Width = 100;
            // 
            // processesPage
            // 
            this.processesPage.Controls.Add(this.processes);
            this.processesPage.Location = new System.Drawing.Point(4, 22);
            this.processesPage.Name = "processesPage";
            this.processesPage.Padding = new System.Windows.Forms.Padding(3);
            this.processesPage.Size = new System.Drawing.Size(601, 359);
            this.processesPage.TabIndex = 1;
            this.processesPage.Text = "Processes";
            this.processesPage.UseVisualStyleBackColor = true;
            // 
            // processes
            // 
            this.processes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processId,
            this.processName});
            this.processes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processes.FullRowSelect = true;
            this.processes.Location = new System.Drawing.Point(3, 3);
            this.processes.Name = "processes";
            this.processes.Size = new System.Drawing.Size(595, 353);
            this.processes.TabIndex = 0;
            this.processes.UseCompatibleStateImageBehavior = false;
            this.processes.View = System.Windows.Forms.View.Details;
            this.processes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnProcessesMouseClick);
            // 
            // processId
            // 
            this.processId.Text = "ID";
            // 
            // processName
            // 
            this.processName.Text = "Name";
            this.processName.Width = 150;
            // 
            // sessionContextMenu
            // 
            this.sessionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectSession,
            this.logoffSession,
            this.refreshSession,
            this.sessionSendMessage});
            this.sessionContextMenu.Name = "sessionContextMenu";
            this.sessionContextMenu.Size = new System.Drawing.Size(159, 92);
            // 
            // disconnectSession
            // 
            this.disconnectSession.Name = "disconnectSession";
            this.disconnectSession.Size = new System.Drawing.Size(158, 22);
            this.disconnectSession.Text = "Disconnect";
            this.disconnectSession.Click += new System.EventHandler(this.OnDisconnectSessionClick);
            // 
            // logoffSession
            // 
            this.logoffSession.Name = "logoffSession";
            this.logoffSession.Size = new System.Drawing.Size(158, 22);
            this.logoffSession.Text = "Logoff";
            this.logoffSession.Click += new System.EventHandler(this.OnLogoffSessionClick);
            // 
            // refreshSession
            // 
            this.refreshSession.Name = "refreshSession";
            this.refreshSession.Size = new System.Drawing.Size(158, 22);
            this.refreshSession.Text = "Refresh";
            this.refreshSession.Click += new System.EventHandler(this.OnRefreshSessionClick);
            // 
            // sessionSendMessage
            // 
            this.sessionSendMessage.Name = "sessionSendMessage";
            this.sessionSendMessage.Size = new System.Drawing.Size(158, 22);
            this.sessionSendMessage.Text = "Send message...";
            this.sessionSendMessage.Click += new System.EventHandler(this.OnSessionSendMessageClick);
            // 
            // processContextMenu
            // 
            this.processContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateProcess});
            this.processContextMenu.Name = "processContextMenu";
            this.processContextMenu.Size = new System.Drawing.Size(129, 26);
            // 
            // terminateProcess
            // 
            this.terminateProcess.Name = "terminateProcess";
            this.terminateProcess.Size = new System.Drawing.Size(128, 22);
            this.terminateProcess.Text = "Terminate";
            this.terminateProcess.Click += new System.EventHandler(this.OnTerminateProcessClick);
            // 
            // refreshSessions2
            // 
            this.refreshSessions2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshSessions2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshSessions2.Name = "refreshSessions2";
            this.refreshSessions2.Size = new System.Drawing.Size(96, 22);
            this.refreshSessions2.Text = "Refresh sessions";
            this.refreshSessions2.Click += new System.EventHandler(this.OnRefreshSessionsClick);
            // 
            // refreshProcess2
            // 
            this.refreshProcess2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshProcess2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshProcess2.Name = "refreshProcess2";
            this.refreshProcess2.Size = new System.Drawing.Size(104, 22);
            this.refreshProcess2.Text = "Refresh processes";
            this.refreshProcess2.Click += new System.EventHandler(this.OnRefreshProcessClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSessions2,
            this.refreshProcess2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 433);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Terminal Services .NET Library";
            this.Shown += new System.EventHandler(this.OnShown);
            this.tabControl1.ResumeLayout(false);
            this.sessionsPage.ResumeLayout(false);
            this.processesPage.ResumeLayout(false);
            this.sessionContextMenu.ResumeLayout(false);
            this.processContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sessionsPage;
        private System.Windows.Forms.TabPage processesPage;
        private System.Windows.Forms.ListView sessions;
        private System.Windows.Forms.ColumnHeader sessionId;
        private System.Windows.Forms.ColumnHeader sessionState;
        private System.Windows.Forms.ColumnHeader sessionWinStationName;
        private System.Windows.Forms.ListView processes;
        private System.Windows.Forms.ColumnHeader processId;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ContextMenuStrip sessionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem disconnectSession;
        private System.Windows.Forms.ToolStripMenuItem logoffSession;
        private System.Windows.Forms.ToolStripMenuItem refreshSession;
        private System.Windows.Forms.ToolStripMenuItem sessionSendMessage;
        private System.Windows.Forms.ContextMenuStrip processContextMenu;
        private System.Windows.Forms.ToolStripMenuItem terminateProcess;
        private System.Windows.Forms.ToolStripButton refreshSessions2;
        private System.Windows.Forms.ToolStripButton refreshProcess2;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

