using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    internal static class Program
    {
        public static string userType = "Guest";
        public static User user = null;
        public static byte[] salt = new byte[128 / 8];
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Register.createAdminIfNotExist();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*user = new User
            {
                Login = "ala",
                Password = "ala",
                Name = "ala"
            };*/
            Application.Run(new MainWindow());
        }
    }
}
