using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Repository.Client
{
    /// <summary>
    /// Wrapper class for HTTP Client.
    /// </summary>
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">HTTP client.</param>
        public HttpClientProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        ///<inheritdoc/>
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return _httpClient.GetAsync(requestUri);
        }

        ///<inheritdoc/>
        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return _httpClient.PostAsync(requestUri, content);
        }

        ///<inheritdoc/>
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return _httpClient.PutAsync(requestUri, content);
        }

        ///<inheritdoc/>
        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return _httpClient.DeleteAsync(requestUri);
        }
    }
}
