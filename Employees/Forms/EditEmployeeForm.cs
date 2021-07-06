using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using Employees.Formatters;
using Employees.Service;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Forms
{
    /// <summary>
    /// Partial class for edit employee form.
    /// </summary>
    [ExcludeFromCodeCoverage] //NOTE: Could be tested with implementation of MVP pattern. Can do if needed. Open for discussion.
    public partial class EditEmployeeForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly int _idOfEmployee;
        private readonly int _currentPage;
        private readonly MainForm _mainForm;
        private readonly ITextFormatter _textFormatter;
        private readonly IEmployeeWebService _employeeWebService;

        /// <summary>
        /// Main constructor for form.
        /// </summary>
        /// <param name="employeeForEdit">Selected employee for edit.</param>
        /// <param name="currentPage">Current grid view page.</param>
        /// <param name="mainForm">Main form. Used for triggering grid refresh.</param>
        public EditEmployeeForm(IEmployee employeeForEdit, int currentPage, MainForm mainForm, IEmployeeWebService employeeWebService)
        {
            InitializeComponent();
            _textFormatter = new TextFormatter();
            _employeeWebService = employeeWebService;
            _mainForm = mainForm;
            _currentPage = currentPage;
            _idOfEmployee = employeeForEdit.Id;
            PopulateFields(employeeForEdit);
        }

        private async void UpdateEmployeeButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;

            bool fieldsAreValid = Helpers.ValidateFields(name, email);
            if (!fieldsAreValid)
            {
                return;
            }

            var employee = new Employee
            {
                Name = name,
                Email = email,
                Gender = Helpers.GetCheckedRadioButtonOnGroupBox(genderGroupBox),
                Status = Helpers.GetCheckedRadioButtonOnGroupBox(statusGroupBox),
            };

            IEmployee result = await _employeeWebService.UpdateEmployeeToWebApiAsync(employee, _idOfEmployee);

            MessageBox.Show(_textFormatter.GenerateUpdateMessage(_idOfEmployee, result));
            log.Info(_textFormatter.GenerateUpdateMessage(_idOfEmployee, result));
            Close();
            var mainFormDataGrid = (DataGridView)Helpers.GetAllControls(_mainForm, typeof(DataGridView)).FirstOrDefault();
            await _mainForm.DefaultRefreshDataGridView(_currentPage, mainFormDataGrid);
        }

        private void PopulateFields(IEmployee employee)
        {
            NameTextBox.Text = employee.Name;
            EmailTextBox.Text = employee.Email;
            Helpers.CheckCorrectRadioButton(this, employee.Gender);
            Helpers.CheckCorrectRadioButton(this, employee.Status);
        }
    }
}