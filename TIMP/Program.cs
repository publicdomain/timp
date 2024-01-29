using System;
using System.Threading;
using System.Windows.Forms;
using NamedPipeWrapper;
using System.Linq;

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
                try
                {
                    var client = new NamedPipeClient<Arguments>("TimpServerPipe");

                    client.Start();
                    client.WaitForConnection(5000);
                    client.PushMessage(new Arguments() { Args = args });
                    client.WaitForDisconnection(5000);
                    client.Stop();
                }
                catch (Exception ex)
                {
                    // TODO Log
                }

                // Halt program flow
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimpApplicationContext());
        }
    }
}
