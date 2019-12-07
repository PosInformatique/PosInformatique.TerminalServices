using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    public class ProcessListViewItem : ListViewItem
    {
        private Process process;

        public ProcessListViewItem(Process process)
        {
            this.process = process;

            this.Text = process.Id.ToString();

            this.SubItems.Add(process.Name);
        }

        public Process Process
        {
            get { return this.process; }
        }
    }
}
