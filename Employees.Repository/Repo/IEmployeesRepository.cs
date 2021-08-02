using System.Net.Http;
using System.Threading.Tasks;
using Employees.Shared.Models;

namespace Employees.Repository.Repo
{
    /// <summary>
    /// Employees repository interface.
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Add employee to web api using POST method.
        /// </summary>
        /// <param name="stringContent">HTTP string content.</param>
        /// <returns></returns>
        Task<IEmployee> AddEmployeeToWebApiAsync(StringContent stringContent);

        /// <summary>
        /// Update employee to web api using PUT method.
        /// </summary>
        /// <param name="putUrl">URL.</param>
        /// <param name="stringContent">HTTP string content.</param>
        /// <returns></returns>
        Task<IEmployee> UpdateEmployeeToWebApiAsync(string putUrl, StringContent stringContent);

        /// <summary>
        /// Delete employee from web api using DELETE method.
        /// </summary>
        /// <param name="deleteUrl">URL.</param>
        /// <returns></returns>
        Task DeleteEmployeeFromWebApiAsync(string deleteUrl);

        /// <summary>
        /// Retrieve employees from web api using GET method and criteria.
        /// </summary>
        /// <param name="getByCriteriaUrl">URL with criteria.</param>
        /// <returns></returns>
        Task<IHostDataList> ViewEmployeesByCriteriaWebApiAsync(string getByCriteriaUrl);

        /// <summary>
        /// Find employee from web api using employee Id.
        /// </summary>
        /// <param name="getByIdUrl">URL with employee Id.</param>
        /// <returns></returns>
        Task<IEmployee> FindEmployeeByIdWebApiAsyncTask(string getByIdUrl);
    }
}