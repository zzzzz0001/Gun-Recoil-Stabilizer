using Gun_recoil_stabilizer.Keystokes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://learn.microsoft.com/en-us/windows/win32/api/winuser/
//https://pinvoke.net/

namespace Gun_recoil_stabilizer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Task.Run(() => garbage_collection());
            Task.Run(() => Keyboard_and_Mouse.Keyboard_Key_Extractor());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_window());   //this is the entry window
        }

        public static Task garbage_collection()
        {
            while (true)
            {
                Thread.Sleep(60000);
                GC.Collect();
            }
        }
    }
}
