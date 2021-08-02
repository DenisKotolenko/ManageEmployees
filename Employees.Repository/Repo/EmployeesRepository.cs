using System;
using System.Net.Http;
using System.Threading.Tasks;
using Employees.Repository.Cache;
using Employees.Service;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Employees.Repository.Repo
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MemoryCache _cache;
        private static MemoryCacheOptions MemoryCacheOptions => new MemoryCacheOptions();

        public EmployeesRepository()
        {
            _cache = new MemoryCache(MemoryCacheOptions);
        }

        public async Task<IEmployee> AddEmployeeToWebApiAsync(StringContent stringContent)
        {
            IEmployee employeeResult = await AddEmployeePostAsync(stringContent);
            return employeeResult;
        }

        public async Task<IEmployee> UpdateEmployeeToWebApiAsync(string putUrl, StringContent stringContent)
        {
            IEmployee employeeResult = await UpdateEmployeePutAsync(putUrl, stringContent);
            DisposeAndRecreateCache();
            return employeeResult;
        }

        public async Task DeleteEmployeeFromWebApiAsync(string deleteUrl)
        {
            await DeleteEmployeeDeleteAsync(deleteUrl);
            DisposeAndRecreateCache();
        }

        public async Task<IHostDataList> ViewEmployeesByCriteriaWebApiAsync(string getByCriteriaUrl)
        {
            IHostDataList hostDataList = await _cache.GetOrCreateLazyAsync(getByCriteriaUrl,
                                                                           async () => await ViewEmployeesByCriteriaGet(getByCriteriaUrl),
                                                                           DateTimeOffset.Now.AddSeconds(Constants.CacheKeyExpirationInSeconds));
            return hostDataList;
        }

        public async Task<IEmployee> FindEmployeeByIdWebApiAsyncTask(string getByIdUrl)
        {
            IEmployee employeeResult = await _cache.GetOrCreateLazyAsync(getByIdUrl,
                                                                         async () => await FindEmployeeByIdGet(getByIdUrl),
                                                                         DateTimeOffset.Now.AddSeconds(Constants.CacheKeyExpirationInSeconds));
            return employeeResult;
        }

        private async Task<IEmployee> FindEmployeeByIdGet(string getByIdUrl)
        {
            using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByIdUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                log.Info($"Successfully retrieved employee from web api: [{HttpMethod.Get}] request LINK: {getByIdUrl}");
                return webApiResult.Data;
            }
        }

        private async Task<IHostDataList> ViewEmployeesByCriteriaGet(string getByCriteriaUrl)
        {
            using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByCriteriaUrl))
            {
                var employeeModelList = await response.Content.ReadAsAsync<HostDataList>();
                Helpers.CheckWebApiResultForErrorsAsync(employeeModelList.Code, "Error");

                log.Info($"Successfully retrieved list of employees from web api: Method: [{HttpMethod.Get}] request LINK: {getByCriteriaUrl}");
                return employeeModelList;
            }
        }

        private async Task DeleteEmployeeDeleteAsync(string deleteUrl)
        {
            using (HttpResponseMessage response = await ApiClient.RestApiClient.DeleteAsync(deleteUrl))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                log.Info($"Successfully deleted employee from web api: Method [{HttpMethod.Delete}] request LINK: {deleteUrl}");
            }
        }

        private async Task<IEmployee> UpdateEmployeePutAsync(string putUrl, StringContent stringContent)
        {
            using (HttpResponseMessage response = await ApiClient.RestApiClient.PutAsync(putUrl, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                log.Info($"Successfully updated employee from web api: Method: [{HttpMethod.Put}] request LINK: {putUrl} with content: {stringContent}");
                return webApiResult.Data;
            }
        }

        private async Task<IEmployee> AddEmployeePostAsync(StringContent stringContent)
        {
            using (HttpResponseMessage response = await ApiClient.RestApiClient.PostAsync(Constants.BaseHostAdress, stringContent))
            {
                var webApiResult = await response.Content.ReadAsAsync<HostData>();
                Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                log.Info($"Successfully added employee to web api: Method: [{HttpMethod.Post}] request LINK: {Constants.BaseHostAdress} Content: {stringContent}");
                return webApiResult.Data;
            }
        }

        private void DisposeAndRecreateCache()
        {
            _cache.Dispose();
            _cache = new MemoryCache(MemoryCacheOptions);
        }
    }
}
