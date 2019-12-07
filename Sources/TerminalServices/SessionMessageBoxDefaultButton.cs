using System;
using System.Collections.Generic;
using System.Text;

namespace PosInformatique.TerminalServices
{
    /// <summary>
    /// Specifies constants defining the default button on a <see cref="Session.SendMessage()"/>
    /// </summary>
    public enum SessionMessageBoxDefaultButton
    {
        /// <summary>
        /// The first button on the message box is the default button.
        /// </summary>
        Button1 = 0,
        /// <summary>
        /// The second button on the message box is the default button.
        /// </summary>
        Button2 = 256,
        /// <summary>
        /// The third button on the message box is the default button.
        /// </summary>
        Button3 = 512,
    }
}
