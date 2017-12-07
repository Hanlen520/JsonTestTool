using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonTestTool
{
    public enum RequestType
    {
        POST,
        POSTUTF8,
        GET,
    }

    public enum menuStripType
    {
        Normal,
        Performance,
        Polling,
        Help,
        About
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
