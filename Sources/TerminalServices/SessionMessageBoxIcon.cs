using System;
using System.Collections.Generic;
using System.Text;

namespace PosInformatique.TerminalServices
{
    /// <summary>
    /// Specifies constants defining which information to display.
    /// </summary>
    public enum SessionMessageBoxIcon
    {
        /// <summary>
        /// The message box contain no symbols.
        /// </summary>
        None = 0,
        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// </summary>
        Error = 16,
        /// <summary>
        /// The message box contains a symbol consisting of a question mark in a circle.
        /// </summary>
        Question = 32,
        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// </summary>
        Warning = 48,
        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// </summary>
        Information = 64
    }
}
