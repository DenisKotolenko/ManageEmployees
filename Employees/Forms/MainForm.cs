using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Service;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Forms
{
    /// <summary>
    /// Partial MainForm class. Not auto generated.
    /// </summary>
    public partial class MainForm : Form
    {
        private const string EditButtonAndColumName = "Edit";
        private const string DeleteButtonAndColumName = "Delete";
        private const int EditButtonColumn = 7;
        private const int DeleteButtonColumn = 8;
        private const int IdColumn = 0;
        private const string FirstPage = "1";
        private int _currentPage;
        private int _maximumNumberOfPages;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used for refreshing grid. This method is used by other forms.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <returns>Current task.</returns>
        public async Task RefreshDataGridView(int page)
        {
            HostDataList resultWithMetaData = await EmployeeWebService.WebServiceSingleton.ViewEmployeesByCriteriaFromWebApiAsync(CreateCriteria(page.ToString()));

            List<Employee> orderedEmployeeList = resultWithMetaData.EmployeeDataList.OrderBy(x => x.Id).ToList();
            ClearGrid();
            FillDataGridViewWithResultsAndButtons(orderedEmployeeList);

            var currentPage = resultWithMetaData.MetaData.PaginationData.Page.ToString();
            var limit = resultWithMetaData.MetaData.PaginationData.Pages.ToString();
            SetCurrentPageAndLimit(currentPage, limit);

            CurrentPageLabel.Text = currentPage;
            SetBackAndNextButtonsAvailability(currentPage);
        }

        private async void AddEmployeeButton_Click_1(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;

            bool fieldsAreValid = Helpers.ValidateFields(name, email);
            if (!fieldsAreValid)
            {
                return;
            }

            var employeeToAdd = new Employee()
            {
                Name = name,
                Email = email,
                Gender = Helpers.GetCheckedRadioButtonOnGroupBox(genderGroupBox),
                Status = Helpers.GetCheckedRadioButtonOnGroupBox(statusGroupBox),
            };

            Employee result = await EmployeeWebService.WebServiceSingleton.AddEmployeeToWebApiAsync(employeeToAdd);

            MessageBox.Show(MessageBoxTextAddEmployee(result));

            CleanAddEmployeeTabFields();
        }
        
        private async void ViewTabSearchButton_Click(object sender, EventArgs e)
        {
            SetCurrentPageAndLimit(FirstPage, string.Empty);
            await RefreshDataGridView(GetCurrentPage());
        }

        private void SetBackAndNextButtonsAvailability(string currentPage)
        {
            if (string.IsNullOrEmpty(currentPage) || currentPage == FirstPage)
            {
                BackPageButton.Enabled = false;
            }
            else
            {
                BackPageButton.Enabled = true;
            }

            NextPageButton.Enabled = GetCurrentPage() < GetMaximumNumberOfPages();
        }

        /// <summary>
        /// NOTE: There is on purpose doubling of id reading / parsing code. Reason for this is because this event listens to every grid cell click and we only need fetching Id for certain cell clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewEmployeeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == EditButtonColumn)
            {
                int id = int.Parse(ViewEmployeeDataGridView.Rows[e.RowIndex].Cells[IdColumn].Value.ToString());

                Employee employeeForEdit = await EmployeeWebService.WebServiceSingleton.GetEmployeeByIdFromWebApiAsync(id);
                
                var editEmployeeForm = new EditEmployeeForm(employeeForEdit, GetCurrentPage(), this);
                editEmployeeForm.Show();
            }

            else if (e.ColumnIndex == DeleteButtonColumn)
            {
                int id = int.Parse(ViewEmployeeDataGridView.Rows[e.RowIndex].Cells[IdColumn].Value.ToString());

                await EmployeeWebService.WebServiceSingleton.DeleteEmployeeFromWebApiAsync(id);
                MessageBox.Show($@"Successfully deleted employee with id: {id}");
                await RefreshDataGridView(GetCurrentPage());
            }
        }

        private void FillDataGridViewWithResultsAndButtons(IEnumerable<Employee> listOfEmployees)
        {
            ViewEmployeeDataGridView.Columns.Add(Helpers.PrepareButtonInCell(EditButtonAndColumName));
            ViewEmployeeDataGridView.Columns.Add(Helpers.PrepareButtonInCell(DeleteButtonAndColumName));

            foreach (Employee employee in listOfEmployees)
            {
                ViewEmployeeDataGridView.Rows.Add(Helpers.ConvertEmplyoeeToDataGridRow(employee));
            }
        }
        
        private Dictionary<string, string> CreateCriteria(string page)
        {
            var criteria = new Dictionary<string, string>();

            string idTextBoxText = IdSearchTextBox.Text;
            string nameTextBoxText = NameSearchTextBox.Text;
            string gender = Helpers.GetCheckedRadioButtonOnGroupBox(GenderSearchGroupBox);
            string status = Helpers.GetCheckedRadioButtonOnGroupBox(StatusSearchGroupBox);

            if (!string.IsNullOrWhiteSpace(page))
            {
                criteria.Add(nameof(HostDataList.MetaData.PaginationData.Page), page);
            }
            if (!string.IsNullOrWhiteSpace(idTextBoxText))
            {
                criteria.Add(nameof(Employee.Id), idTextBoxText);
            }
            if (!string.IsNullOrWhiteSpace(nameTextBoxText))
            {
                criteria.Add(nameof(Employee.Name), nameTextBoxText);
            }
            if (!string.IsNullOrEmpty(gender))
            {
                criteria.Add(nameof(Employee.Gender), gender);
            }
            if (!string.IsNullOrEmpty(status))
            {
                criteria.Add(nameof(Employee.Status), status);
            }
            
            return criteria;
        }

        private void ClearGrid()
        {
            ViewEmployeeDataGridView.Rows.Clear();
            if (ViewEmployeeDataGridView.Columns.Contains(EditButtonAndColumName) && ViewEmployeeDataGridView.Columns.Contains(DeleteButtonAndColumName))
            {
                ViewEmployeeDataGridView.Columns.RemoveAt(DeleteButtonColumn);
                ViewEmployeeDataGridView.Columns.RemoveAt(EditButtonColumn);
            }
            
            ViewEmployeeDataGridView.Refresh();
        }

        private void ClearViewTabSearchFields()
        {
            IdSearchTextBox.Text = string.Empty;
            NameSearchTextBox.Text = string.Empty;
            Helpers.UncheckAllRadioButtonsOnTabPage(ViewTabPage);
        }

        private void CleanAddEmployeeTabFields()
        {
            NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            MaleRadioButton.Checked = true;
            ActiveStatusSearchRadioButton.Checked = true;
        }
        
        private string MessageBoxTextAddEmployee(Employee result)
        {
            return $"Employee with id: {result.Id} Successfully added. Full data: Name: {result.Name}, Email: {result.Email}, Gender: {result.Gender}, Status: {result.Status}, Created: {result.Created}, Updated: {result.Updated} ";
        }

        private void SetCurrentPageAndLimit(string page, string limit)
        {
            int.TryParse(page, out int parsedPage);
            int.TryParse(limit, out int parsedLimit);

            _currentPage = parsedPage;
            _maximumNumberOfPages = parsedLimit;
        }

        private int GetCurrentPage()
        {
            return _currentPage;
        }

        private int GetMaximumNumberOfPages()
        {
            return _maximumNumberOfPages;
        }

        private async void BackPageButton_Click(object sender, EventArgs e)
        {
            int backPage = GetCurrentPage() - 1;
            if (backPage > 0)
            {
                await RefreshDataGridView(backPage);
            }
            else
            {
                MessageBox.Show($@"There is no back page. Currently on page: {GetCurrentPage()}");
            }
        }

        private async void NextPageButton_Click(object sender, EventArgs e)
        {
            int nextPage = GetCurrentPage() + 1;
            if (nextPage <= GetMaximumNumberOfPages())
            {
                await RefreshDataGridView(nextPage);
            }
            else
            {
                MessageBox.Show($@"There is no next page. Maximum number of pages: {GetMaximumNumberOfPages()}");
            }
        }

        private void ExportToCsvButton_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = ViewEmployeeDataGridView;
            CsvHelper.ExportDataGridToCsv(dataGridView);
        }

        private async void ClearButton_Click_1(object sender, EventArgs e)
        {
            ClearViewTabSearchFields();
            SetCurrentPageAndLimit(FirstPage, string.Empty);
            await RefreshDataGridView(int.Parse(FirstPage));
            ClearGrid();
        }
    }
}
