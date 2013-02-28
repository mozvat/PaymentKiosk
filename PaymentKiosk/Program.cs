using System;
using System.Windows.Forms;

namespace PaymentKiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //"START"
 
            // Test if input arguments were supplied and correct format
            if ((args.Length == 1) && (args[0].ToUpper() == "START"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain("START"));
            }
            else// if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
        }
    }
}
