using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public sealed class Session : IObjectIdentifier
    {
        private string winStationName;
        private int id;
        private Server server;
        private bool refreshValues;

        private SessionConnectionState connectionState;
        /// <summary>
        /// Session format used in the <see cref="ToString"/> method.
        /// </summary>
        private const string SessionFormat = "{0} - {1} (State : {2})";

        internal Session(Server server, int id)
        {
            this.server = server;
            this.id = id;

            this.refreshValues = true;
        }

        public Server Server
        {
            get { return this.server; }
        }

        /// <summary>
        /// WinStation name of the <see cref="Session"/>.
        /// </summary>
        public string WinStationName
        {
            get
            {
                this.RefreshValues();
                return this.winStationName;
            }
        }
        /// <summary>
        /// Get the identifier of the <see cref="Session"/>.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        public SessionMessageBoxResult SendMessage(string message, bool waitUserSessionAnswer)
        {
            return this.SendMessage(message, waitUserSessionAnswer, "");
        }
        public SessionMessageBoxResult SendMessage(string message, bool waitUserSessionAnswer, string title)
        {
            return this.SendMessage(message, waitUserSessionAnswer, title, SessionMessageBoxButtons.OK);
        }
        public SessionMessageBoxResult SendMessage(string message, bool waitUserSessionAnswer, string title, SessionMessageBoxButtons buttons)
        {
            return this.SendMessage(message, waitUserSessionAnswer, title, buttons, SessionMessageBoxIcon.Information);
        }
        public SessionMessageBoxResult SendMessage(string message, bool waitUserSessionAnswer, string title, SessionMessageBoxButtons buttons,
            SessionMessageBoxIcon icon)
        {
            return this.SendMessage(message, waitUserSessionAnswer, title, buttons, icon, SessionMessageBoxDefaultButton.Button1);
        }
        public SessionMessageBoxResult SendMessage(string message, bool waitUserSessionAnswer, string title,
            SessionMessageBoxButtons buttons, SessionMessageBoxIcon icon, SessionMessageBoxDefaultButton defaultButton)
        {
            int response;
            int style;

            style = (int)buttons | (int)icon | (int)defaultButton;

            if (NativeMethods.WTSSendMessage(this, title, message, style, TimeSpan.Zero, out response, waitUserSessionAnswer) == false)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            return (SessionMessageBoxResult)response;
        }

        public SessionConnectionState ConnectionState
        {
            get
            {
                this.RefreshValues();
                return this.connectionState;
            }
        }

        public void Refresh()
        {
            this.refreshValues = true;
        }

        private void RefreshValues()
        {
            if (this.refreshValues == true)
            {
                //Refresh values of the Session object
                this.connectionState = this.QueryConnectionState();
                this.winStationName = this.QueryWinStationName();

                this.refreshValues = false;
            }
        }

        private SessionConnectionState QueryConnectionState()
        {
            IntPtr ppBuffer;
            int pBytesReturned;

            NativeMethods.WTSQuerySessionInformation(this, NativeMethods.WTS_INFO_CLASS.WTSConnectState, out ppBuffer, out pBytesReturned);
            
            try
            {
                return (SessionConnectionState)Marshal.ReadInt32(ppBuffer);
            }
            finally
            {
                NativeMethods.WTSFreeMemory(ppBuffer);
            }
        }
        private string QueryWinStationName()
        {
            IntPtr ppBuffer;
            int pBytesReturned;

            NativeMethods.WTSQuerySessionInformation(this, NativeMethods.WTS_INFO_CLASS.WTSWinStationName, out ppBuffer, out pBytesReturned);

            try
            {
                return Marshal.PtrToStringAuto(ppBuffer);
            }
            finally
            {
                NativeMethods.WTSFreeMemory(ppBuffer);
            }
        }

        public void Disconnect()
        {
            this.Disconnect(true);
        }
        public void Disconnect(bool wait)
        {
            NativeMethods.WTSDisconnectSession(this, wait);
        }

        public void Logoff()
        {
            this.Logoff(true);
        }
        public void Logoff(bool wait)
        {
            NativeMethods.WTSLogoffSession(this, wait);
        }

        /// <summary>
        /// Return a <see cref="String"/> that contains the <see cref="SessionId"/> and the <see cref="WinStation"/>
        /// of the <see cref="Session"/>.
        /// </summary>
        /// <returns>The <see cref="SessionId"/> and the <see cref="WinStation"/> of the <see cref="Session"/></returns>
        public override string ToString()
        {
            return string.Format(SessionFormat, this.Id, this.WinStationName, this.ConnectionState);
        }
    }
}
