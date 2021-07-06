using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Employees.Shared.Models;

namespace Employees.Shared.Helpers
{
    /// <summary>
    /// Helper class for various purposes.
    /// </summary>
    [ExcludeFromCodeCoverage] //static classes are not testable. However testing could be done with wrapper.
    public static class Helpers
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Creates criteria string from dictionary.
        /// </summary>
        /// <param name="criteriaDictionary">Dictionary  with criteria.</param>
        /// <returns>Formated string with criteria for web api to use.</returns>
        public static string CriteriaUrlStringCreator(IDictionary<string, string> criteriaDictionary)
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in criteriaDictionary)
            {
                string key = keyValuePair.Key.ToLower();
                string value = keyValuePair.Value;
                stringBuilder.Append(stringBuilder.Length > 0 ? $"{Constants.Constants.AndHttpDelimeter}{key}{Constants.Constants.EqualHttpDelimeter}{value}" : $"{key}{Constants.Constants.EqualHttpDelimeter}{value}");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Used for setting checked attribute on radio button on control.
        /// </summary>
        /// <param name="control">Control for scanner.</param>
        /// <param name="radioButtonText">RadioButton text</param>
        public static void CheckCorrectRadioButton(Control control, string radioButtonText)
        {
            IEnumerable<Control> controls = GetAllControls(control, typeof(RadioButton));
            foreach (Control ct in controls)
            {
                var radioButton = (RadioButton) ct;
                if (radioButton.Text == radioButtonText)
                {
                    radioButton.Checked = true;
                }
            }
        }

        /// <summary>
        /// Finds checked radio button on group box.
        /// </summary>
        /// <param name="groupBox">Group box to search.</param>
        /// <returns>Text of checked radio button.</returns>
        public static string GetCheckedRadioButtonOnGroupBox(GroupBox groupBox)
        {
            RadioButton statusGroupCheckedRadioButton = groupBox.Controls.OfType<RadioButton>()
                                                                .FirstOrDefault(r => r.Checked);
            return statusGroupCheckedRadioButton != null ? statusGroupCheckedRadioButton.Text : string.Empty;
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
                const string text = @"Empty name field. Please fill in correct name.";
                log.Info(text);
                MessageBox.Show(text);
                isValid = false;
            }

            if (!email.IsValidEmail())
            {
                const string text = @"Email is not valid. Please enter email in format: xxxx@xxxx.xx";
                log.Info(text);
                MessageBox.Show(text);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Used to retrieve all controls. Usually used for gathering all radio buttons.
        /// </summary>
        /// <param name="control">Control on which searching for controls will happen.</param>
        /// <param name="type">Type of control to get. Usage: typeof(RadioButton)</param>
        /// <returns>List of all controls of selected type in control. Example: List of RadioButtons</returns>
        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            List<Control> enumerable = controls.ToList();
            return enumerable.SelectMany(ctrls => GetAllControls(ctrls, type)).Concat(enumerable).Where(c => c.GetType() == type);
        }

        /// <summary>
        /// Used to prepare buttons for data grid view cells.
        /// </summary>
        /// <param name="text">Name / text of button.</param>
        /// <returns>Prepared button column.</returns>
        public static DataGridViewColumn PrepareButtonInCell(string text)
        {
            return new DataGridViewButtonColumn
            {
                HeaderText = text,
                Text = text,
                Name = text,
                UseColumnTextForButtonValue = true,
            };
        }

        /// <summary>
        /// Converts employee to object array.
        /// </summary>
        /// <param name="employee">Employee to convert.</param>
        /// <returns>Object array.</returns>
        public static object[] ConvertEmplyoeeToDataGridRow(IEmployee employee)
        {
            return new object[]
            {
                employee.Id.ToString(),
                employee.Name,
                employee.Email,
                employee.Gender,
                employee.Status,
                employee.Created.ToLongTimeString(),
                employee.Updated.ToLongTimeString(),
            };
        }

        /// <summary>
        /// Remove checked all radio buttons on tab page.
        /// </summary>
        /// <param name="tabPageToUncheck">Tab page.</param>
        public static void UncheckAllRadioButtonsOnTabPage(TabPage tabPageToUncheck)
        {
            IEnumerable<Control> controls = GetAllControls(tabPageToUncheck, typeof(RadioButton));
            foreach (Control control in controls)
            {
                var radioButton = (RadioButton) control;
                if (radioButton.Checked)
                {
                    radioButton.Checked = false;
                }
            }
        }
    }
}