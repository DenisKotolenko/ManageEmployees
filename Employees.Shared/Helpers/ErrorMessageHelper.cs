using System;
using System.Windows.Forms;

namespace Employees.Shared.Helpers
{
    /// <summary>
    /// Class for error message formating.
    /// </summary>
    public static class ErrorMessageHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Shows formatted message box for received exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        public static void GenerateErrorMessageBox(Exception ex)
        {
            log.Error(ex.StackTrace);
            log.Error(ex.Message);
            MessageBox.Show($"ErrorMessage: {ex.Message} {Constants.Constants.MultipleNextLines} InnerException: {ex.InnerException}", Constants.Constants.ErrorMessageTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Creates new exception from received parameters.
        /// </summary>
        /// <param name="exception">Exception.</param>
        /// <param name="link">Api link which causes problems.</param>
        /// <param name="httpCommand">HTTP command used to trigger link.</param>
        /// <returns>Formatted exception with additional details.</returns>
        public static Exception CreateExceptionWithWebLink(Exception exception, string link, string httpCommand)
        {
            return new Exception($"Message: {exception.Message} {Constants.Constants.MultipleNextLines} InnerException: {exception.InnerException} {Constants.Constants.MultipleNextLines} Link: {link} {Constants.Constants.MultipleNextLines} HttpCommandUsed: {httpCommand}.");
        }
    }
}
