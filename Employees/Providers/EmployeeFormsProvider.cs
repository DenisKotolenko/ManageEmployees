using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;

namespace Employees.Providers
{
    /// <summary>
    /// Employee forms provider class. Used for providing and working with windows forms controls.
    /// </summary>
    [ExcludeFromCodeCoverage] //NOTE: Actually this is hard to unit test because of win forms classes. Open for discussion.
    public class EmployeeFormsProvider : IEmployeeFormsProvider
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <inheritdoc />
        public void ClearGrid(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            if (dataGrid.Columns.Contains(Constants.EditButtonAndColumName) && dataGrid.Columns.Contains(Constants.DeleteButtonAndColumName))
            {
                dataGrid.Columns.RemoveAt(Constants.DeleteButtonColumn);
                dataGrid.Columns.RemoveAt(Constants.EditButtonColumn);
            }
            dataGrid.Refresh();
            log.Info("Grid successfully updated.");
        }

        /// <inheritdoc />
        public int GetIdFromDataGrid(DataGridView dataGrid, DataGridViewCellEventArgs e)
        {
            return int.Parse(dataGrid.Rows[e.RowIndex].Cells[Constants.IdColumn].Value.ToString());
        }

        /// <inheritdoc />
        public Tuple<string, string> RefreshDataGridViewWithCriteria(DataGridView dataGrid, int page, IHostDataList hostDataList)
        {
            var currentPage = hostDataList.MetaData.PaginationData.Page.ToString();
            var limit = hostDataList.MetaData.PaginationData.Pages.ToString();
            IEnumerable<Employee> orderedEmployeeList = hostDataList.EmployeeDataList.OrderBy(x => x.Id).ToList();

            ClearGrid(dataGrid);
            FillDataGridViewWithResultsAndButtons(orderedEmployeeList, dataGrid);

            log.Info($"Current page of the grid is: {currentPage}. Limit is: {limit}. Grid successfully filled with: {orderedEmployeeList.Count()} number of employees");

            return Tuple.Create(currentPage, limit);
        }

        private void FillDataGridViewWithResultsAndButtons(IEnumerable<Employee> listOfEmployees, DataGridView dataGridView)
        {
            dataGridView.Columns.Add(Helpers.PrepareButtonInCell(Constants.EditButtonAndColumName));
            dataGridView.Columns.Add(Helpers.PrepareButtonInCell(Constants.DeleteButtonAndColumName));

            foreach (Employee employee in listOfEmployees)
            {
                dataGridView.Rows.Add(Helpers.ConvertEmplyoeeToDataGridRow(employee));
            }
        }
    }
}