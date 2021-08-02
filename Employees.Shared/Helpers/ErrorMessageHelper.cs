using System;
using System.Windows.Forms;

namespace Employees.Shared.Helpers
{
    public static class MessageHelpers
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void GenerateErrorMessageBox(Exception ex)
        {
            log.Error(ex.StackTrace);
            log.Error(ex.Message);
            MessageBox.Show(ex.Message, Constants.Constants.ErrorMessageTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
