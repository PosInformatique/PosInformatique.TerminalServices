using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public class ProcessCollection : ObjectIdentifierCollection<Process>
    {
        internal ProcessCollection()
            : base()
        {

        }

        public Process[] Find(string processName)
        {
            List<Process> temp;

            temp = new List<Process>();

            foreach (Process process in this)
            {
                if (string.Compare(process.Name, processName, true, CultureInfo.CurrentCulture) == 0)
                    temp.Add(process);
            }

            return temp.ToArray();
        }
    }
}
