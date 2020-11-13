using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 
        private static Mutex mutex = new Mutex();

        public static bool IsOtherInstanceRunning()
        {
            string mutexName = Application.ProductName + "_MultiStartPrevent";
            mutex = new Mutex(false, mutexName);

            if (mutex.WaitOne(0, true))
                return false;
            else
                return true;
        }



        [STAThread]
        static void Main()
        {
            mutex.WaitOne();
            if (!IsOtherInstanceRunning())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MainWindow());
            }
            else
                MessageBox.Show("Diese Anwendung kann nicht mehrfach ausgeführt werden!", Application.ProductName, 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
}

