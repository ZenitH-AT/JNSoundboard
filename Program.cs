using System;
using System.Runtime.InteropServices;   //GuidAttribute
using System.Reflection;                //Assembly
using System.Threading;                 //Mutex
using System.Windows.Forms;

namespace JNSoundboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();

            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                //prevent multiple instances
                if (!mutex.WaitOne(0, false)) return;

                GC.Collect();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
