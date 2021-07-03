using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Employees.Service;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Forms
{
    /// <summary>
    /// Partial MainForm class. Not auto generated.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private string MessageBoxTextAddEmployee(Employee result)
        {
            return $"Employee with id: {result.Id} Successfully added. Full data: Name: {result.Name}, Email: {result.Email}, Gender: {result.Gender}, Status: {result.Status}, Created: {result.Created}, Updated: {result.Updated} ";
        }

        private async void AddEmployeeButton_Click_1(object sender, EventArgs e)
        {
            bool fieldsAreValid = Helpers.ValidateFields(NameTextBox.Text, EmailTextBox.Text);
            if (!fieldsAreValid)
            {
                return;
            }

            string gender = Helpers.GetCheckedRadioButtonOnGroupBox(genderGroupBox);
            string status = Helpers.GetCheckedRadioButtonOnGroupBox(statusGroupBox);

            var employeeToAdd = new Employee()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Gender = gender,
                Status = status,
            };

            Employee result = await EmployeeWebService.WebServiceSingleton.AddEmployeeToWebApiAsync(employeeToAdd);

            MessageBox.Show(MessageBoxTextAddEmployee(result));

            CleanAddTabFields();
        }
        
        private async void ViewTabSearchButton_Click(object sender, EventArgs e)
        {
            string gender = Helpers.GetCheckedRadioButtonOnGroupBox(GenderSearchGroupBox);
            string status = Helpers.GetCheckedRadioButtonOnGroupBox(StatusSearchGroupBox);

            //TODO: properly generate criteria
            var criteria = new Dictionary<string, string>();
            //criteria.Add(nameof(Employee.Id), IdSearchTextBox.Text);
            //criteria.Add(nameof(Employee.Name), NameSearchTextBox.Text);
            criteria.Add(nameof(Employee.Gender), gender);
            criteria.Add(nameof(Employee.Status), status);

            List<Employee> result = await EmployeeWebService.WebServiceSingleton.ViewEmployeesByCriteriaFromWebApiAsync(criteria);

            //TODO: continue from here
            foreach (var employee in result)
            {
                MessageBox.Show(MessageBoxTextAddEmployee(employee));
            }

            CleanViewTabSearchFields();
        }

        private void CleanViewTabSearchFields()
        {
            IdSearchTextBox.Text = string.Empty;
            NameSearchTextBox.Text = string.Empty;
            UncheckAllRadioButtonsOnTabPage(ViewTabPage);
        }

        private void CleanAddTabFields()
        {
            NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            MaleRadioButton.Checked = true;
            ActiveStatusSearchRadioButton.Checked = true;
        }

        private void UncheckAllRadioButtonsOnTabPage(TabPage tabPageToUncheck)
        {
            IEnumerable<Control> controls = GetAllControls(tabPageToUncheck, typeof(RadioButton));
            foreach (Control control in controls)
            {
                var radioButton = (RadioButton)control;
                if (radioButton.Checked)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrls => GetAllControls(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        }



    }
}
