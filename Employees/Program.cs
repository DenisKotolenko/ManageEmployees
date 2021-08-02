using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Employees.Forms;
using Employees.Repository.Repo;
using Employees.Service;
using Employees.Shared.Helpers;

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
            try
            {
                ApiClient.InitializeClient();
                IEmployeesRepository employeesRepository = new EmployeesRepository();
                IEmployeeWebService webService = new EmployeeWebService(employeesRepository);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(webService));
            }
            catch (Exception ex)
            {
                MessageHelpers.GenerateErrorMessageBox(ex);
            }
        }
    }
}