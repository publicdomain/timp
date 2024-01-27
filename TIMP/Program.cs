using System;
using System.Threading;
using System.Windows.Forms;

namespace TIMP
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// The mutex.
        /// </summary>
        private static Mutex mutex = null;

        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // The mutex flag
            bool mutexFlag;

            // Set the mutex
            mutex = new Mutex(true, "timpMutex", out mutexFlag);

            // Check the mutex flag
            if (!mutexFlag)
            {
                // There is an instance of TIMP running, exit
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimpApplicationContext());
        }
    }
}
