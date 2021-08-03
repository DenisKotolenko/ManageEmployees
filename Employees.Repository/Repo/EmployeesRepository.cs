using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Employees.Repository.Cache;
using Employees.Repository.Client;
using Employees.Shared.Constants;
using Employees.Shared.Helpers;
using Employees.Shared.Models;
using log4net;
using Microsoft.Extensions.Caching.Memory;

namespace Employees.Repository.Repo
{
    /// <summary>
    /// Employees repository class.
    /// </summary>
    public class EmployeesRepository : IEmployeesRepository
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IMemoryCache _cache;
        private static MemoryCacheOptions MemoryCacheOptions => new MemoryCacheOptions();
        private readonly object _lock = new object();
        private readonly IHttpClientProvider _httpClientProvider;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClientProvider">HttpClient provider.</param>
        public EmployeesRepository(IHttpClientProvider httpClientProvider)
        {
            _cache = new MemoryCache(MemoryCacheOptions);
            _httpClientProvider = httpClientProvider;
        }

        /// <summary>
        /// DI constructor for unit testing.
        /// </summary>
        /// <param name="httpClientProvider">Http client provider.</param>
        /// <param name="cache">Memory cache.</param>
        public EmployeesRepository(IHttpClientProvider httpClientProvider, IMemoryCache cache)
        {
            _cache = cache;
            _httpClientProvider = httpClientProvider;
        }

        ///<inheritdoc/>
        public async Task<IEmployee> AddEmployeeToWebApiAsync(StringContent stringContent)
        {
            try
            {
                using (HttpResponseMessage response = await _httpClientProvider.PostAsync(Constants.BaseHostAdress, stringContent))
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

        ///<inheritdoc/>
        public async Task<IEmployee> UpdateEmployeeToWebApiAsync(string putUrl, StringContent stringContent)
        {
            try
            {
                using (HttpResponseMessage response = await _httpClientProvider.PutAsync(putUrl, stringContent))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);

                    log.Info($"Successfully updated employee from web api: Method: [{HttpMethod.Put}] request LINK: {putUrl} with content: {stringContent}");
                    DisposeAndRecreateCache();
                    return webApiResult.Data;
                }
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
                using (HttpResponseMessage response = await _httpClientProvider.DeleteAsync(deleteUrl))
                {
                    var webApiResult = await response.Content.ReadAsAsync<HostData>();
                    Helpers.CheckWebApiResultForErrorsAsync(webApiResult.Code, webApiResult.Data?.ErrorMessage);
                    DisposeAndRecreateCache();
                    log.Info($"Successfully deleted employee from web api: Method [{HttpMethod.Delete}] request LINK: {deleteUrl}");
                }
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

        /// <summary>
        /// Finds employee by id.
        /// </summary>
        /// <param name="getByIdUrl">Full URL with employee id.</param>
        /// <returns>Employee.</returns>
        internal async Task<IEmployee> FindEmployeeByIdGet(string getByIdUrl)
        {
            try
            {
                using (HttpResponseMessage response = await _httpClientProvider.GetAsync(getByIdUrl))
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

        /// <summary>
        /// Retrieves employees by criteria from web api using GET. Internal for unit testing.
        /// </summary>
        /// <param name="getByCriteriaUrl">Full URL with criteria.</param>
        /// <returns>IHostDataList which contains list of employees.</returns>
        internal async Task<IHostDataList> ViewEmployeesByCriteriaGet(string getByCriteriaUrl)
        {
            try
            {
                using (HttpResponseMessage response = await _httpClientProvider.GetAsync(getByCriteriaUrl))
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
        
        /// <summary>
        /// Implemented simple locking mechanism in order to prevent multiple threads from disposing and renewing cache.
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
