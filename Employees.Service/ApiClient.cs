using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Employees.Shared.Constants;

namespace Employees.Service
{
    /// <summary>
    /// Class for web api client.
    /// </summary>
    public static class ApiClient
    {
        /// <summary>
        /// This constant should not be moved from this class. Moving it will cause possible security issue.
        /// NOTE: Actually this constant should be part of configuration file.
        /// </summary>
        private const string Token = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";

        /// <summary>
        /// This static constructor ensures thread safety. Details on Jon Skeet article: https://csharpindepth.com/articles/singleton
        /// </summary>
        static ApiClient() 
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as before field initialization
        }

        /// <summary>
        /// HttpClient used for communicating over HTTP to host web api.
        /// </summary>
        public static HttpClient RestApiClient { get; private set; } = new HttpClient();

        /// <summary>
        /// Initialization of HttpClient and setting up base address host web api.
        /// </summary>
        public static void InitializeClient()
        {
            RestApiClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseHostAdress)
            };
            RestApiClient.DefaultRequestHeaders.Accept.Clear();
            RestApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Bearer, Token);
            RestApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.ResponseFormat));
        }
    }
}