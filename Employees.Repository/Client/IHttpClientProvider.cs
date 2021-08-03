using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Repository.Client
{
    /// <summary>
    /// Interface for HTTP client.
    /// </summary>
    public interface IHttpClientProvider
    {
        /// <summary>
        /// Wrapper for HttpClient GetAsync.
        /// </summary>
        /// <param name="requestUri">URL.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string requestUri);
        /// <summary>
        /// Wrapper for HttpClient PostAsync.
        /// </summary>
        /// <param name="requestUri">URL.</param>
        /// <param name="content">HTTP StringContent.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        /// <summary>
        /// Wrapper for HttpClient PutAsync.
        /// </summary>
        /// <param name="requestUri">URL.</param>
        /// <param name="content">HTTP StringContent.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        /// <summary>
        /// Wrapper for HttpClient DeleteAsync.
        /// </summary>
        /// <param name="requestUri">URL.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
    }
}
