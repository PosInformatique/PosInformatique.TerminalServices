using System;
using System.Collections.Generic;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public enum SessionConnectionState
    {
        /// <summary>
        /// User logged on to WinStation
        /// </summary>
        Active,
        
        /// <summary>
        /// WinStation connected to client
        /// </summary>
        Connected,

        /// <summary>
        /// In the process of connecting to client
        /// </summary>
        ConnectQuery,

        /// <summary>
        /// Shadow
        /// </summary>
        Shadow,

        /// <summary>
        /// WinStation logged on without client
        /// </summary>
        Disconnected,

        /// <summary>
        /// Waiting for client to connect
        /// </summary>
        Idle,

        /// <summary>
        /// WinStation is listening for connection
        /// </summary>
        Listen,

        /// <summary>
        /// WinStation is being reset
        /// </summary>
        Reset,

        /// <summary>
        /// WinStation is down due to error
        /// </summary>
        Down,

        /// <summary>
        /// WinStation in initialization
        /// </summary>
        Init
    }
}
