using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Service;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Forms
{
    public partial class EditEmployeeForm : Form
    {
        private readonly int _idOfEmployee;
        private readonly int _currentPage;
        private readonly MainForm _mainForm;

        public EditEmployeeForm(Employee employeeForEdit, int currentPage, MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _currentPage = currentPage;
            _idOfEmployee = employeeForEdit.Id;
            PopulateFields(employeeForEdit);
        }

        private void PopulateFields(Employee employee)
        {
            NameTextBox.Text = employee.Name;
            EmailTextBox.Text = employee.Email;
            CheckCorrectRadioButton(employee.Gender);
            CheckCorrectRadioButton(employee.Status);
        }

        private void CheckCorrectRadioButton(string value)
        {
            IEnumerable<Control> controls = Helpers.GetAllControls(this, typeof(RadioButton));
            foreach (Control control in controls)
            {
                var radioButton = (RadioButton)control;
                if (radioButton.Text == value)
                {
                    radioButton.Checked = true;
                }
            }
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

            var employee = new Employee()
            {
                Name = name,
                Email = email,
                Gender = Helpers.GetCheckedRadioButtonOnGroupBox(genderGroupBox),
                Status = Helpers.GetCheckedRadioButtonOnGroupBox(statusGroupBox),
            };

            Employee result = await EmployeeWebService.WebServiceSingleton.UpdateEmployeeToWebApiAsync(employee, _idOfEmployee);

            MessageBox.Show(GenerateUpdateMessage(result));
            Close();
            await _mainForm.RefreshDataGridView(_currentPage);
        }

        private string GenerateUpdateMessage(Employee employee)
        {
            return $"Updated employee with id: {_idOfEmployee} Updated Employee from web api: Name: {employee.Name}, Email: {employee.Email}, Status: {employee.Status}, Gender: {employee.Gender}, Created: {employee.Created.ToLongTimeString()}, Updated: {employee.Updated.ToLongTimeString()}";
        }
    }
}
