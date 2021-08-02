using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Employees.Forms;
using Employees.Repository.Client;
using Employees.Repository.Repo;
using Employees.Service;

namespace Employees
{
    /// <summary>
    /// Main entry point class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                log.Error(ex.StackTrace);
                log.Error(ex.Message);
            }
        }
    }
}