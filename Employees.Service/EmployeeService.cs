using System;
using System.Collections.Generic;
using System.Net;
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
    public class EmployeeService : IEmployeeService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="employeesRepository">Employee repository with caching.</param>
        public EmployeeService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        ///<inheritdoc/>
        public async Task<IEmployee> GetEmployeeByIdFromWebApiAsync(int employeeId)
        {
            var getByIdUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{employeeId}";

            try
            {
                IEmployee foundEmployee = await _employeesRepository.FindEmployeeByIdWebApiAsyncTask(getByIdUrl);
                return foundEmployee;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, getByIdUrl, WebRequestMethods.Http.Get);
            }
        }

        ///<inheritdoc/>
        public async Task<IEmployee> AddEmployeeToWebApiAsync(IEmployee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            string json = JsonConvert.SerializeObject(employee);
            var stringContent = new StringContent(json, Encoding.UTF8, Constants.ResponseFormat);

            try
            {
                IEmployee hostDataResult = await _employeesRepository.AddEmployeeToWebApiAsync(stringContent);
                return hostDataResult;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, Constants.BaseHostAdress, WebRequestMethods.Http.Post);
            }
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

            try
            {
                IEmployee updatedEmployee = await _employeesRepository.UpdateEmployeeToWebApiAsync(putUrl, stringContent);
                return updatedEmployee;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, putUrl, WebRequestMethods.Http.Put);
            }
        }

        ///<inheritdoc/>
        public async Task DeleteEmployeeFromWebApiAsync(int id)
        {
            var deleteUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{id}";

            try
            {
                await _employeesRepository.DeleteEmployeeFromWebApiAsync(deleteUrl);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, deleteUrl, Constants.HttpConstantDelete);
            }
        }

        ///<inheritdoc/>
        public async Task<IHostDataList> ViewEmployeesByCriteriaFromWebApiAsync(Dictionary<string, string> criteria)
        {
            var getByCriteriaUrl = $"{Constants.BaseHostAdress}{Constants.QuestionMarkHttpDelimeter}{Helpers.CriteriaUrlStringCreator(criteria)}";

            try
            {
                IHostDataList listOfEmployees = await _employeesRepository.ViewEmployeesByCriteriaWebApiAsync(getByCriteriaUrl);
                return listOfEmployees;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, getByCriteriaUrl, WebRequestMethods.Http.Get);
            }
        }

        ///<inheritdoc/>
        public async Task CheckIfRestApiIsOnline()
        {
            try
            {
                await _employeesRepository.ViewEmployeesByCriteriaWebApiAsync(Constants.BaseHostAdress);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ErrorMessageHelper.CreateExceptionWithWebLink(ex, Constants.BaseHostAdress, WebRequestMethods.Http.Get);
            }
        }
    }
}