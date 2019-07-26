using CodexoftSoftLock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SoftLocker locker = new SoftLocker("WPOS",
              Application.StartupPath + "\\RegFile.reg",
             // Environment.GetFolderPath(Environment.SpecialFolder.System) +
             Application.StartupPath + "\\WPOSTM.dbf",
              "Phone: +xx xx xxxxxxx\nMobile: +xx xxx xxxxxx",
              15, 10, "786");

            byte[] MyOwnKey = { 97, 250,  1,  5,  84, 21,   7, 63,
                         4,  54, 87, 56, 123, 10,   3, 62,
                         7,   9, 20, 36,  37, 21, 101, 57};
            locker.TripleDESKey = MyOwnKey;
            // if you don't call this part the program will
            //use default key to encryption

            SoftLocker.RunTypes RT = locker.ShowDialog();
            bool is_trial;
            if (RT != SoftLocker.RunTypes.Expired)
            {
                if (RT == SoftLocker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;

                var master = new Master();
                Master.Instance = master;
                Application.Run(master);
            }

            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //log exception
           
                LogException(e.ExceptionObject as Exception);
            var exception = (e.ExceptionObject as Exception);
                Message.Error("Something went wrong. Please contact administrator." + exception.Message + ". " + exception.InnerException?.Message);
                Application.Exit();

                void LogException(Exception ex)
                {

                    if (!File.Exists("Errors.Log")) File.WriteAllText("Errors.Log", "");
                    File.AppendAllLines("Errors.Log", new string[] { ex.Message +
                ". " + ex.InnerException?.Message +" : " +DateTime.Now});
                }


            
        }

    }
}
