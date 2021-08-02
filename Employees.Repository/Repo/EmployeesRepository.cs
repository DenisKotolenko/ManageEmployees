using System;
using System.Net.Http;
using System.Threading.Tasks;
using Employees.Repository.Cache;
using Employees.Repository.Client;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Employees.Repository.Repo
{
    /// <summary>
    /// Employees repository class.
    /// </summary>
    public class EmployeesRepository : IEmployeesRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MemoryCache _cache;
        private static MemoryCacheOptions MemoryCacheOptions => new MemoryCacheOptions();
        private readonly object _lock = new object();

        /// <summary>
        /// Constructor.
        /// </summary>
        public EmployeesRepository()
        {
            _cache = new MemoryCache(MemoryCacheOptions);
        }

        ///<inheritdoc/>
        public async Task<IEmployee> AddEmployeeToWebApiAsync(StringContent stringContent)
        {
            try
            {
                IEmployee employeeResult = await AddEmployeePostAsync(stringContent);
                return employeeResult;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        ///<inheritdoc/>
        public async Task<IEmployee> UpdateEmployeeToWebApiAsync(string putUrl, StringContent stringContent)
        {
            try
            {
                IEmployee employeeResult = await UpdateEmployeePutAsync(putUrl, stringContent);
                DisposeAndRecreateCache();
                return employeeResult;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        ///<inheritdoc/>
        public async Task DeleteEmployeeFromWebApiAsync(string deleteUrl)
        {
            try
            {
                await DeleteEmployeeDeleteAsync(deleteUrl);
                DisposeAndRecreateCache();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        ///<inheritdoc/>
        public async Task<IHostDataList> ViewEmployeesByCriteriaWebApiAsync(string getByCriteriaUrl)
        {
            try
            {
                IHostDataList hostDataList = await _cache.GetOrCreateLazyAsync(getByCriteriaUrl,
                                                                                   async () => await ViewEmployeesByCriteriaGet(getByCriteriaUrl),
                                                                                   DateTimeOffset.Now.AddSeconds(Constants.CacheKeyExpirationInSeconds));
                return hostDataList;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        ///<inheritdoc/>
        public async Task<IEmployee> FindEmployeeByIdWebApiAsyncTask(string getByIdUrl)
        {
            try
            {
                IEmployee employeeResult = await _cache.GetOrCreateLazyAsync(getByIdUrl,
                                                                                 async () => await FindEmployeeByIdGet(getByIdUrl),
                                                                                 DateTimeOffset.Now.AddSeconds(Constants.CacheKeyExpirationInSeconds));
                return employeeResult;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        private async Task<IEmployee> FindEmployeeByIdGet(string getByIdUrl)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByIdUrl))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                    log.Info($"Successfully retrieved employee from web api: [{HttpMethod.Get}] request LINK: {getByIdUrl}");
                    return webApiResult.Data;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        private async Task<IHostDataList> ViewEmployeesByCriteriaGet(string getByCriteriaUrl)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.RestApiClient.GetAsync(getByCriteriaUrl))
                {
                    var employeeModelList = await response.Content.ReadAsAsync<HostDataList>();
                    Helpers.CheckWebApiResultForErrorsAsync(employeeModelList.Code, "Error");

                    log.Info($"Successfully retrieved list of employees from web api: Method: [{HttpMethod.Get}] request LINK: {getByCriteriaUrl}");
                    return employeeModelList;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error(ex.InnerException);
                throw;
            }
        }

        private async Task DeleteEmployeeDeleteAsync(string deleteUrl)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.RestApiClient.DeleteAsync(deleteUrl))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                    log.Info($"Successfully deleted employee from web api: Method [{HttpMethod.Delete}] request LINK: {deleteUrl}");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        private async Task<IEmployee> UpdateEmployeePutAsync(string putUrl, StringContent stringContent)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.RestApiClient.PutAsync(putUrl, stringContent))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                    log.Info($"Successfully updated employee from web api: Method: [{HttpMethod.Put}] request LINK: {putUrl} with content: {stringContent}");
                    return webApiResult.Data;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        private async Task<IEmployee> AddEmployeePostAsync(StringContent stringContent)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.RestApiClient.PostAsync(Constants.BaseHostAdress, stringContent))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                    log.Info($"Successfully added employee to web api: Method: [{HttpMethod.Post}] request LINK: {Constants.BaseHostAdress} Content: {stringContent}");
                    return webApiResult.Data;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Implemented simple locking mechanism in order to prevent multiple threads from disposing and renewing cache.
        /// NOTE: This kind of implementation should NEVER EVER be used in bigger application. Cache should be newed only once and then manipulated.
        /// </summary>
        private void DisposeAndRecreateCache()
        {
            lock(_lock)
            {
                _cache.Dispose();
                _cache = new MemoryCache(MemoryCacheOptions);
            }
        }
    }
}
