using System;
using System.Windows.Forms;
using TitanGym_Presentation.Modules.Login.Forms;

namespace TitanGym_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainPlTitanGymStartProgram());
            Application.Run(new UCLoginTitanGym());
        }
    }
}
