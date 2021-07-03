using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Shared.Constants;
using Employees.Shared.Models;
using Newtonsoft.Json;

namespace Employees.Service
{
    /// <summary>
    /// Web service used for communication with web api.
    /// </summary>
    public class EmployeeWebService
    {
        private readonly string _noConnectionErrorMessage = $"No connection to: {Constants.BaseHostAdress}";
        private readonly string questionMarkHttpDelimeter = "?";
        private readonly string andHttpDelimeter = "&";
        private readonly string equalHttpDelimeter = "=";
        private readonly string errorMessage = "Error";

        // Explicit static constructor to tell C# compiler
        // not to mark type as before field initialization
        static EmployeeWebService()
        {
        }

        private EmployeeWebService()
        {
        }

        public static EmployeeWebService WebServiceSingleton { get; } = new EmployeeWebService();

        /// <summary>
        /// Do a GET call to check if host is on line. If host service does not return HttpStatusCode 200 on general GET request it has error or is off-line.
        /// </summary>
        /// <returns></returns>
        public async Task<HttpStatusCode> CheckIfHostIsOnlineAsync()
        {
            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.GetAsync(Constants.BaseHostAdress))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostDataList>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, _noConnectionErrorMessage);

                return webApiResult.Code;
            }
        }

        /// <summary>
        /// GET: Retrieves employee from web service by id.
        /// </summary>
        /// <param name="employeeId">Id of employee to retrieve.</param>
        /// <returns>Filled up EmployeeModel. Otherwise throws error.</returns>
        public async Task<Employee> GetEmployeeByIdFromWebApiAsync(int employeeId)
        {
            string getByIdUrl = $"{Constants.BaseHostAdress}{employeeId}";

            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.GetAsync(getByIdUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data.ErrorMessage);

                return webApiResult.Data;
            }
        }

        /// <summary>
        /// POST: Adds employee to web api.
        /// </summary>
        /// <param name="employee">Employee to be added.</param>
        /// <returns>Newly created Employee. Otherwise throws error.</returns>
        public async Task<Employee> AddEmployeeToWebApiAsync(Employee employee)
        {
            string json = JsonConvert.SerializeObject(employee);
            var stringContent = new StringContent(json, Encoding.UTF8, Constants.ResponseFormat);

            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.PostAsync(Constants.BaseHostAdress, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data.ErrorMessage);

                return webApiResult.Data;
            }
        }

        /// <summary>
        /// PUT: Updates selected employee by id.
        /// </summary>
        /// <param name="employee">Employee for update.</param>
        /// <param name="id">Id of employee to be updated.</param>
        /// <returns>Updated Employee. Otherwise throws error.</returns>
        public async Task<Employee> UpdateEmployeeToWebApiAsync(Employee employee, int id)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, Constants.ResponseFormat);
            string putUrl = $"{Constants.BaseHostAdress}{id}";

            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.PutAsync(putUrl, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data.ErrorMessage);

                return webApiResult.Data;
            }
        }

        /// <summary>
        /// DELETE: Deletes employee on web api based on employee id.
        /// </summary>
        /// <param name="id">Id of employee to be deleted.</param>
        /// <returns>No body/content if successful. Otherwise throws error.</returns>
        public async Task DeleteEmployeeFromWebApiAsync(int id)
        {
            string deleteUrl = $"{Constants.BaseHostAdress}{id}";

            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.DeleteAsync(deleteUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data.ErrorMessage);
            }
        }
        
        /// <summary>
        /// GET: Retrieve list of employees per criteria.
        /// </summary>
        /// <param name="criteria">Dictionary for HTTP field criteria.</param>
        /// <returns>List of selected employees.</returns>
        public async Task<List<Employee>> ViewEmployeesByCriteriaFromWebApiAsync(Dictionary<string, string> criteria)
        {
            string getByCriteriaUrl = $"{Constants.BaseHostAdress}{questionMarkHttpDelimeter}{CriteriaUrlStringCreator(criteria)}";

            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.GetAsync(getByCriteriaUrl))
            {
                var employeeModelList = await response.Content.ReadAsAsync<HostDataList>();
                CheckWebApiResultForErrorsAsync(employeeModelList.Code, errorMessage);

                return employeeModelList.EmployeeDataList;
            }
        }

        /// <summary>
        /// GET: Retrieve one page of employees from web api.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <returns>List of employees.</returns>
        public async Task<List<Employee>> ViewEmployeesByPageFromWebApiAsync(int page)
        {
            string pagingUrl = $"{Constants.BaseHostAdress}{questionMarkHttpDelimeter}page={page}";
            
            using (HttpResponseMessage response = await ApiClientHelper.RestApiClient.GetAsync(pagingUrl))
            {
                var employeeModelList = await response.Content.ReadAsAsync<HostDataList>();
                CheckWebApiResultForErrorsAsync(employeeModelList.Code, errorMessage);

                return employeeModelList.EmployeeDataList;
            }
        }
        
        private void CheckWebApiResultForErrorsAsync(HttpStatusCode httpStatusCode, string errorMessage )
        {
            if (!Enum.IsDefined(typeof(ValidHttpStatusCodeEnum), (int)httpStatusCode))
            {
                throw new Exception($"ErrorCode: {httpStatusCode} ErrorMessage: {errorMessage}");
            }
        }

        private string CriteriaUrlStringCreator(Dictionary<string, string> criteriaDictionary)
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in criteriaDictionary)
            {
                stringBuilder.Append(stringBuilder.Length > 0 ? $"{andHttpDelimeter}{keyValuePair.Key}{equalHttpDelimeter}{keyValuePair.Value}" : $"{keyValuePair.Key}{equalHttpDelimeter}{keyValuePair.Value}");
            }
            return stringBuilder.ToString();
        }
    }
}
