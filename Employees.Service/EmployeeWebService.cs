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
    /*NOTE: Could be unit tested with wrappers around ApiClient but that will
    require opening HttpClient (removing static and opening up HttpClient to be set).
    Did not want to do that because I wanted to force application to only have 1 instance of ApiClient trough whole application.
    
    In practice this code MUST be tested as it contains crucial logic for whole application.
    THIS PART IS OPEN FOR DISCUSSION!
    */

    /// <summary>
    /// Employee service class. Used as main point for communication with web api.
    /// </summary>
    public class EmployeeWebService : IEmployeeWebService
    {
        private const string ErrorMessage = "Error";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<inheritdoc/>
        public async Task<IEmployee> GetEmployeeByIdFromWebApiAsync(int employeeId)
        {
            var getByIdUrl = $"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{employeeId}";

            using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByIdUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                log.Info($"Successfully retrieved employee from web api: [{WebRequestMethods.Http.Get}] request LINK: {getByIdUrl}");
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

                log.Info($"Successfully added employee to web api: Method: [{HttpMethod.Post}] request LINK: {Constants.BaseHostAdress} Content: {stringContent}");
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

                log.Info($"Successfully updated employee from web api: Method: [{HttpMethod.Put}] request LINK: {putUrl} with content: {stringContent}");
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

                log.Info($"Successfully deleted employee from web api: Method [{HttpMethod.Delete}] request LINK: {deleteUrl}");
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

                log.Info($"Successfully retrieved list of employees from web api: Method: [{HttpMethod.Get}] request LINK: {getByCriteriaUrl}");
                return employeeModelList;
            }
        }

        private void CheckWebApiResultForErrorsAsync(HttpStatusCode httpStatusCode, string errorMsg)
        {
            if (!Enum.IsDefined(typeof(ValidHttpStatusCodeEnum), (int) httpStatusCode))
            {
                var errorMessage = $"Error received from web api. HttpStatusCode: {httpStatusCode} ErrorMessage: {errorMsg}";
                log.Error(errorMessage);
                throw new Exception(errorMessage);
            }
        }
    }
}