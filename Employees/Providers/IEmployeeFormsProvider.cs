using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Shared.Models;

namespace Employees.Providers
{
    /// <summary>
    /// Interface for employee forms provider.
    /// </summary>
    public interface IEmployeeFormsProvider
    {
        /// <summary>
        /// Clears entered data grid.
        /// </summary>
        /// <param name="dataGridView">Data grid to clear.</param>
        void ClearGrid(DataGridView dataGridView);

        /// <summary>
        /// Gets id of selected employee from data grid view cell.
        /// </summary>
        /// <param name="dataGrid">Data grid.</param>
        /// <param name="e">Data grid view cell that was clicked on.</param>
        /// <returns></returns>
        int GetIdFromDataGrid(DataGridView dataGrid, DataGridViewCellEventArgs e);

        /// <summary>
        /// Refreshes data grid with data received from web api, depending on criteria.
        /// </summary>
        /// <param name="dataGrid">Data grid for refresh.</param>
        /// <param name="page">Grid view current page.</param>
        /// <param name="hostDataList">List with all data received from web api.s</param>
        /// <returns></returns>
        Tuple<string, string> RefreshDataGridViewWithCriteria(DataGridView dataGrid, int page, IHostDataList hostDataList);
    }
}