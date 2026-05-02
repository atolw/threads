using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsThreadingApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}