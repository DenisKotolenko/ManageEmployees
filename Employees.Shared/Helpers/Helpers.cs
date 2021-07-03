using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Employees.Shared.Helpers
{
    /// <summary>
    /// Helper class for various purposes.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Finds checked radio button on group box.
        /// </summary>
        /// <param name="groupBox">Group box to search.</param>
        /// <returns>Text of checked radio button.</returns>
        public static string GetCheckedRadioButtonOnGroupBox(GroupBox groupBox)
        {
            RadioButton statusGroupCheckedRadioButton = groupBox.Controls.OfType<RadioButton>()
                                                                .First(r => r.Checked);
            return statusGroupCheckedRadioButton.Text;
        }

        /// <summary>
        /// Check if string is valid email address.
        /// </summary>
        /// <param name="email">Email string.</param>
        /// <returns>True if mail is valid. False if not.</returns>
        public static bool IsValidEmail(this string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        /// <summary>
        /// Validates fields.
        /// </summary>
        /// <param name="name">Name of Employee.</param>
        /// <param name="email">Email.</param>
        /// <returns>True if fields are valid. False if fields are not valid.</returns>
        public static bool ValidateFields(string name, string email)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(@"Empty name field. Please fill in correct name.");
                isValid = false;
            }

            if (!email.IsValidEmail())
            {
                MessageBox.Show(@"Email is not valid. Please enter email in format: xxxx@xxxx.xx");
                isValid = false;
            }

            return isValid;
        }
    }
}
