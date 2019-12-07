using System;
using System.Collections.Generic;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public class Process : IObjectIdentifier
    {
        private Session session;
        private Server server;
        private int id;
        private string name;

        internal Process(Server server, int id, string name, int sessionId)
        {
            this.server = server;
            this.session = server.Sessions.Find(sessionId);
            this.id = id;
            this.name = name;
        }

        internal Server Server
        {
            get { return this.server; }
        }

        public Session Session
        {
            get { return this.session; }
        }
        public int Id
        {
            get { return this.id; }
        }
        public string Name
        {
            get { return this.name; }
        }

        public bool Terminate()
        {
            return this.Terminate(0);
        }
        public bool Terminate(int exitCode)
        {
            return NativeMethods.WTSTerminateProcess(this, exitCode);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Id, this.Name);
        }
    }
}
