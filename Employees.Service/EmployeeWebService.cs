using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;
using Newtonsoft.Json;

namespace Employees.Service
{
    /// <summary>
    /// Web service used for communication with web api.
    /// </summary>
    public class EmployeeWebService : IEmployeeWebService
    {
        private const string ErrorMessage = "Error";

        ///<inheritdoc/>
        public async Task<IEmployee> GetEmployeeByIdFromWebApiAsync(int employeeId)
        {
            var getByIdUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{employeeId}";

            using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByIdUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                return webApiResult.Data;
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

            using (HttpResponseMessage response = await ApiClient.RestApiClient.PostAsync(Constants.BaseHostAdress, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                return webApiResult.Data;
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

            using (HttpResponseMessage response = await ApiClient.RestApiClient.PutAsync(putUrl, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                return webApiResult.Data;
            }
        }

        ///<inheritdoc/>
        public async Task DeleteEmployeeFromWebApiAsync(int id)
        {
            var deleteUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{id}";

            using (HttpResponseMessage response = await ApiClient.RestApiClient.DeleteAsync(deleteUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);
            }
        }

        ///<inheritdoc/>
        public async Task<IHostDataList> ViewEmployeesByCriteriaFromWebApiAsync(Dictionary<string, string> criteria)
        {
            var getByCriteriaUrl = $"{Constants.BaseHostAdress}{Constants.QuestionMarkHttpDelimeter}{Helpers.CriteriaUrlStringCreator(criteria)}";

            using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByCriteriaUrl))
            {
                var employeeModelList = await response.Content.ReadAsAsync<HostDataList>();
                CheckWebApiResultForErrorsAsync(employeeModelList.Code, ErrorMessage);

                return employeeModelList;
            }
        }

        private void CheckWebApiResultForErrorsAsync(HttpStatusCode httpStatusCode, string errorMsg)
        {
            if (!Enum.IsDefined(typeof(ValidHttpStatusCodeEnum), (int) httpStatusCode))
            {
                throw new Exception($"ErrorCode: {httpStatusCode} ErrorMessage: {errorMsg}");
            }
        }
    }
}