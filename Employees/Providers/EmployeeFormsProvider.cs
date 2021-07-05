using System;
using System.Collections.Generic;
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
    public class EmployeeFormsProvider : IEmployeeFormsProvider
    {
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