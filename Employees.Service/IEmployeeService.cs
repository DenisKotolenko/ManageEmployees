using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Shared.Models;

namespace Employees.Service
{
    /// <summary>
    /// Interface for web api client
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// GET: Retrieves employee from web service by id.
        /// </summary>
        /// <param name="employeeId">Id of employee to retrieve.</param>
        /// <returns>Filled up EmployeeModel. Otherwise throws error.</returns>
        Task<IEmployee> GetEmployeeByIdFromWebApiAsync(int employeeId);

        /// <summary>
        /// POST: Adds employee to web api.
        /// </summary>
        /// <param name="employee">Employee to be added.</param>
        /// <returns>Newly created Employee. Otherwise throws error.</returns>
        Task<IEmployee> AddEmployeeToWebApiAsync(IEmployee employee);

        /// <summary>
        /// PUT: Updates selected employee by id.
        /// </summary>
        /// <param name="employee">Employee for update.</param>
        /// <param name="id">Id of employee to be updated.</param>
        /// <returns>Updated Employee. Otherwise throws error.</returns>
        Task<IEmployee> UpdateEmployeeToWebApiAsync(IEmployee employee, int id);

        /// <summary>
        /// DELETE: Deletes employee on web api based on employee id.
        /// </summary>
        /// <param name="id">Id of employee to be deleted.</param>
        /// <returns>No body/content if successful. Otherwise throws error.</returns>
        Task DeleteEmployeeFromWebApiAsync(int id);

        /// <summary>
        /// GET: Retrieve list of employees per criteria.
        /// </summary>
        /// <param name="criteria">Dictionary for HTTP field criteria.</param>
        /// <returns>List of selected employees.</returns>
        Task<IHostDataList> ViewEmployeesByCriteriaFromWebApiAsync(Dictionary<string, string> criteria);

        /// <summary>
        /// Checks if rest web api is on line.
        /// </summary>
        /// <returns>List of employees.</returns>
        Task CheckIfRestApiIsOnline();
    }
}