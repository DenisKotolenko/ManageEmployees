using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Formatters;
using Employees.Providers;
using Employees.Service;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Forms
{
    /// <summary>
    /// Partial MainForm class. Not auto generated.
    /// </summary>
    [ExcludeFromCodeCoverage] //NOTE: Could be tested with implementation of MVP pattern. Can do if needed. Open for discussion.
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEmployeeFormsProvider _employeeFormsProvider;
        private readonly IPageProvider _pageProvider;
        private readonly ITextFormatter _textFormatter;
        private readonly IEmployeeWebService _employeeWebService;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MainForm(IEmployeeWebService webService)
        {
            _employeeWebService = webService;
            _employeeFormsProvider = new EmployeeFormsProvider();
            _pageProvider = new PageProvider();
            _textFormatter = new TextFormatter();
            InitializeComponent();
        }

        /// <summary>
        /// Used for refreshing grid. This method is used by other forms.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <param name="dataGrid">Data grid.</param>
        /// <returns>Current task.</returns>
        public async Task DefaultRefreshDataGridView(int page, DataGridView dataGrid)
        {
            IHostDataList resultWithMetaData = await _employeeWebService.ViewEmployeesByCriteriaFromWebApiAsync(GetCriteria(page));

            Tuple<string, string> currentPageAndLimit = _employeeFormsProvider.RefreshDataGridViewWithCriteria(dataGrid, page, resultWithMetaData);

            _pageProvider.SetCurrentPageAndLimit(currentPageAndLimit.Item1, currentPageAndLimit.Item2);
            CurrentPageLabel.Text = currentPageAndLimit.Item1;
            BackPageButton.Enabled = _pageProvider.GetBackButtonAvailability();
            NextPageButton.Enabled = _pageProvider.GetNextButtonAvailability();

            log.Info($"Successfully set up current page and limit on data grid view. Current page {currentPageAndLimit.Item1}. Max page: {currentPageAndLimit.Item2}");
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

            var employeeToAdd = new Employee
            {
                Name = name,
                Email = email,
                Gender = Helpers.GetCheckedRadioButtonOnGroupBox(genderGroupBox),
                Status = Helpers.GetCheckedRadioButtonOnGroupBox(statusGroupBox),
            };

            IEmployee result = await _employeeWebService.AddEmployeeToWebApiAsync(employeeToAdd);

            MessageBox.Show(_textFormatter.AddEmployeeText(result));
            log.Info(_textFormatter.AddEmployeeText(result));

            CleanAddEmployeeTabFields();
        }

        private async void ViewTabSearchButton_Click(object sender, EventArgs e)
        {
            _pageProvider.SetCurrentPageAndLimit(Constants.FirstPage, string.Empty);
            await DefaultRefreshDataGridView(_pageProvider.GetCurrentPage(), ViewEmployeeDataGridView);
        }

        /// <summary>
        /// NOTE: There is on purpose doubling of id get code. Reason for this is because this event listens to every grid cell
        /// click and we only need fetching Id for certain button cell clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewEmployeeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Constants.EditButtonColumn)
            {
                int id = _employeeFormsProvider.GetIdFromDataGrid(ViewEmployeeDataGridView, e);

                IEmployee employeeForEdit = await _employeeWebService.GetEmployeeByIdFromWebApiAsync(id);

                var editEmployeeForm = new EditEmployeeForm(employeeForEdit, _pageProvider.GetCurrentPage(), this, _employeeWebService);
                editEmployeeForm.Show();
            }

            else
            {
                if (e.ColumnIndex == Constants.DeleteButtonColumn)
                {
                    int id = _employeeFormsProvider.GetIdFromDataGrid(ViewEmployeeDataGridView, e);

                    await _employeeWebService.DeleteEmployeeFromWebApiAsync(id);
                    MessageBox.Show(_textFormatter.SuccesfullyDeletedEmployeeText(id));
                    log.Info(_textFormatter.SuccesfullyDeletedEmployeeText(id));
                    await DefaultRefreshDataGridView(_pageProvider.GetCurrentPage(), ViewEmployeeDataGridView);
                }
            }
        }

        private async void BackPageButton_Click(object sender, EventArgs e)
        {
            int currentPage = _pageProvider.GetCurrentPage();
            int backPage = currentPage - 1;

            if (backPage > 0)
            {
                await DefaultRefreshDataGridView(backPage, ViewEmployeeDataGridView);
            }
            else
            {
                log.Info(_textFormatter.NoBackPageText(currentPage));
                MessageBox.Show(_textFormatter.NoBackPageText(currentPage));
            }
        }

        private async void NextPageButton_Click(object sender, EventArgs e)
        {
            int maximumPages = _pageProvider.GetMaximumNumberOfPages();
            int nextPage = _pageProvider.GetCurrentPage() + 1;
            if (nextPage <= maximumPages)
            {
                await DefaultRefreshDataGridView(nextPage, ViewEmployeeDataGridView);
            }
            else
            {
                log.Info(_textFormatter.NoNextPageText(maximumPages));
                MessageBox.Show(_textFormatter.NoNextPageText(maximumPages));
            }
        }

        private void ExportToCsvButton_Click(object sender, EventArgs e)
        {
            CsvHelper.ExportDataGridToCsv(ViewEmployeeDataGridView);
        }

        private async void ClearButton_Click_1(object sender, EventArgs e)
        {
            ClearViewTabSearchFields();
            _pageProvider.SetCurrentPageAndLimit(Constants.FirstPage, string.Empty);
            await DefaultRefreshDataGridView(int.Parse(Constants.FirstPage), ViewEmployeeDataGridView);
            _employeeFormsProvider.ClearGrid(ViewEmployeeDataGridView);
            
            NextPageButton.Enabled = false;
            log.Info("items on tab and grid successfully cleaned.");

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

        private Dictionary<string, string> GetCriteria(int page)
        {
            return new Criteria(
                IdSearchTextBox.Text,
                NameSearchTextBox.Text,
                Helpers.GetCheckedRadioButtonOnGroupBox(GenderSearchGroupBox),
                Helpers.GetCheckedRadioButtonOnGroupBox(StatusSearchGroupBox),
                page.ToString()
                ).CreateCriteria();
        }
    }
}