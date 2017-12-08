using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonTestTool
{
    public enum RequestMode
    {
        POST = 1,
        POSTUTF8 = 2,
        GET = 3,
        Non = 0,
    }

    public enum menuStripType
    {
        Normal = 1,
        Performance = 2,
        Auto = 3,
        Polling = 4,
        Help = 5,
        About = 6,
        None = 0,
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
