using System;
using System.Windows.Forms;
using Employees.Forms;
using Employees.Service;
using Employees.Shared.Constants;

namespace Employees
{
    /// <summary>
    /// Main entry point class.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. Also checks for connection to host before running.
        /// </summary>
        [STAThread]
        static async System.Threading.Tasks.Task Main()
        {
            ApiClientHelper.InitializeClient();

            try
            {
                await EmployeeWebService.WebServiceSingleton.CheckIfHostIsOnlineAsync();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, $@"Error with connection to host: {Constants.HostApi}");
            }
        }
    }
}
