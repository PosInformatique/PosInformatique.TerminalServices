using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public sealed class Server : IDisposable
    {
        /// <summary>
        /// The handle of the <see cref="Server"/>.
        /// </summary>
        private IntPtr handle;
        /// <summary>
        /// Collection of <see cref="Session"/> currently on the server.
        /// </summary>
        private SessionCollection sessions;
        private bool refreshSessions;

        private ProcessCollection processes;
        private bool refreshProcesses;

        private Server(IntPtr handle)
        {
            this.handle = handle;

            this.sessions = new SessionCollection();
            this.refreshSessions = true;

            this.processes = new ProcessCollection();
            this.refreshProcesses = true;
        }

        /// <summary>
        /// Get the internal handle of the server.
        /// </summary>
        internal IntPtr Handle
        {
            get { return this.handle; }
        }

        public static Server Connect(string serverName)
        {
            IntPtr handle;

            handle = NativeMethods.WTSOpenServer(serverName);
            if (handle == null)
                return null;

            return new Server(handle);
        }

        /// <summary>
        /// Get all opens
        /// </summary>
        public SessionCollection Sessions
        {
            get
            {
                this.RefreshSessionsInternal();
                return this.sessions;
            }
        }

        public void RefreshSessions()
        {
            this.refreshSessions = true;
        }

        /// <summary>
        /// Fill the <see cref="Sessions"/> collection.
        /// </summary>
        private void RefreshSessionsInternal()
        {
            if (this.refreshSessions == true)
            {
                IntPtr sessionInfo;
                int count;

                if (NativeMethods.WTSEnumerateSessions(new HandleRef(this, this.handle), out sessionInfo, out count) == true)
                {
                    try
                    {
                        NativeMethods.WTS_SESSION_INFO[] sessions;
                        Session session;
                        List<int> temp;         //List of sessionId returned by the API

                        temp = new List<int>();
                        sessions = NativeMethods.GetStructuresArrays<NativeMethods.WTS_SESSION_INFO>(sessionInfo, count);

                        //For each returned session, refresh or add it in the "sessions" member
                        foreach (NativeMethods.WTS_SESSION_INFO s in sessions)
                        {
                            session = this.sessions.Find(s.SessionId);
                            if (session != null)
                            {
                                //The session already exist, so refresh it
                                session.Refresh();
                            }
                            else
                            {
                                //The session doesn't exist, create it !
                                this.sessions.Add(new Session(this, s.SessionId));
                            }

                            temp.Add(s.SessionId);
                        }

                        //Now, remove all non-existing session in the "sessions" member
                        RemoveObjectsIdentifier(this.sessions, temp);
                    }
                    finally
                    {
                        NativeMethods.WTSFreeMemory(sessionInfo);
                    }
                }
                else
                {
                    this.sessions.Clear();
                }

                this.refreshSessions = false;
            }
        }

        public ProcessCollection Processes
        {
            get
            {
                this.RefreshProcessesInternal();
                return this.processes;
            }
        }

        public void RefreshProcesses()
        {
            this.refreshProcesses = true;
        }

        private void RefreshProcessesInternal()
        {
            if (this.refreshProcesses == true)
            {
                IntPtr processesInfo;
                int count;

                if (NativeMethods.WTSEnumerateProcesses(new HandleRef(this, this.handle), out processesInfo, out count) == true)
                {
                    try
                    {
                        NativeMethods.WTS_PROCESS_INFO[] processes;
                        Process process;
                        List<int> temp;         //List of sessionId returned by the API

                        temp = new List<int>();
                        processes = NativeMethods.GetStructuresArrays<NativeMethods.WTS_PROCESS_INFO>(processesInfo, count);

                        //For each returned session, refresh or add it in the "sessions" member
                        foreach (NativeMethods.WTS_PROCESS_INFO p in processes)
                        {
                            process = this.processes.Find(p.ProcessId);
                            if (process == null)
                            {
                                //The process doesn't exist, create it !
                                this.processes.Add(new Process(this, p.ProcessId, p.pProcessName, p.SessionId));
                            }

                            temp.Add(p.ProcessId);
                        }

                        //Now, remove all non-existing process in the "processes" member
                        RemoveObjectsIdentifier(this.processes, temp);
                    }
                    finally
                    {
                        NativeMethods.WTSFreeMemory(processesInfo);
                    }
                }
                else
                {
                    this.processes.Clear();
                }

                this.refreshProcesses = false;
            }
        }

        private static void RemoveObjectsIdentifier<T>(ObjectIdentifierCollection<T> collection, List<int> ids)
            where T : class, IObjectIdentifier
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                //If the list of returned previous does not contain the object id, remove it
                if (ids.Contains(collection[i].Id) == false)
                    collection.RemoveAt(i);
            }
        }

        /// <summary>
        /// Get the current <see cref="Session"/> that is currently attached to the physical console.
        /// The physical console is the monitor, keyboard, and mouse.
        /// </summary>
        public Session CurrentSession
        {
            get
            {
                int sessionId;

                sessionId = NativeMethods.WTSGetActiveConsoleSessionId();

                return this.Sessions.Find(sessionId);
            }
        }

        

        public static string[] GetServers()
        {
            return GetServers(null);
        }
        /// <summary>
        /// Return all terminal servers in the specified <paramref name="domain"/>.
        /// </summary>
        /// <param name="domain">Domain to be queried. null to specified the current domain.</param>
        /// <returns>A <see cref="String"/> array containing all terminal servers in the specified <see cref="domain"/></returns>
        /// <remarks>This function will not work if NetBT is disabled.</remarks>
        public static string[] GetServers(string domain)
        {
            IntPtr serveurInfo;
            int count;

            if (NativeMethods.WTSEnumerateServers(domain, 0, 1, out serveurInfo, out count) == true)
            {
                try
                {
                    NativeMethods.WTS_SERVER_INFO[] servers;
                    string[] result;

                    result = new string[count];
                    servers = NativeMethods.GetStructuresArrays<NativeMethods.WTS_SERVER_INFO>(serveurInfo, count);

                    for (int i = 0; i < count; i++)
                        result[i] = servers[i].pServerName;

                    return result;
                }
                finally
                {
                    NativeMethods.WTSFreeMemory(serveurInfo);
                }
            }

            //TODO : Throw exception
            return null;
        }

        #region IDisposable Membres

        ~Server()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool managed)
        {
            if (this.handle != IntPtr.Zero)
            {
                NativeMethods.WTSCloseServer(new HandleRef(this, this.handle));
                this.handle = IntPtr.Zero;
            }
        }

        #endregion
    }
}
