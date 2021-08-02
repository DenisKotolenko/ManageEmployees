using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Repository.Repo;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;
using Newtonsoft.Json;

namespace Employees.Service
{
    /// <summary>
    /// Employee service class. Used as main point for communication with web api.
    /// </summary>
    public class EmployeeWebService : IEmployeeWebService
    {
        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="employeesRepository">Employee repository with caching.</param>
        public EmployeeWebService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        ///<inheritdoc/>
        public async Task<IEmployee> GetEmployeeByIdFromWebApiAsync(int employeeId)
        {
            var getByIdUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{employeeId}";

            IEmployee foundEmployee = await _employeesRepository.FindEmployeeByIdWebApiAsyncTask(getByIdUrl);
            return foundEmployee;
        }

        public async Task<IEmployee> AddEmployeeToWebApiAsync(IEmployee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            string json = JsonConvert.SerializeObject(employee);
            var stringContent = new StringContent(json, Encoding.UTF8, Constants.ResponseFormat);

            IEmployee hostDataResult = await _employeesRepository.AddEmployeeToWebApiAsync(stringContent);
            return hostDataResult;
        }

        ///<inheritdoc/>
        public async Task<IEmployee> UpdateEmployeeToWebApiAsync(IEmployee employee, int id)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, Constants.ResponseFormat);
            var putUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{id}";

            IEmployee updatedEmployee = await _employeesRepository.UpdateEmployeeToWebApiAsync(putUrl, stringContent);
            return updatedEmployee;
        }

        ///<inheritdoc/>
        public async Task DeleteEmployeeFromWebApiAsync(int id)
        {
            var deleteUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{id}";

            await _employeesRepository.DeleteEmployeeFromWebApiAsync(deleteUrl);
        }

        ///<inheritdoc/>
        public async Task<IHostDataList> ViewEmployeesByCriteriaFromWebApiAsync(Dictionary<string, string> criteria)
        {
            var getByCriteriaUrl = $"{Constants.BaseHostAdress}{Constants.QuestionMarkHttpDelimeter}{Helpers.CriteriaUrlStringCreator(criteria)}";

            IHostDataList listOfEmployees = await _employeesRepository.ViewEmployeesByCriteriaWebApiAsync(getByCriteriaUrl);
            return listOfEmployees;
        }
    }
}