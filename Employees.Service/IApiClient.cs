using System.Net.Http;

namespace Employees.Service
{
    /// <summary>
    /// Interface for api client.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// HttpClient used for communicating over HTTP to host.
        /// </summary>
        HttpClient RestApiClient { get; }

        /// <summary>
        /// Initialization of HttpClient and setting up base address host web api.
        /// </summary>
        void InitializeClient();
    }
}