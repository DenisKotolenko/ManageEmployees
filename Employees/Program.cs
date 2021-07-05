using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Employees.Forms;
using Employees.Service;

namespace Employees
{
    /// <summary>
    /// Main entry point class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApiClient.InitializeClient();
            IEmployeeWebService webService = new EmployeeWebService();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(webService));
        }
    }
}