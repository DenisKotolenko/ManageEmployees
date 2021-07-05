using System.Net;
using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for receiving JSON data from web api.
    /// </summary>
    public class HostData
    {
        /// <summary>
        /// HTTP status code from web api.
        /// </summary>
        [JsonProperty("code")]
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Meta data from web api.
        /// </summary>
        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }

        /// <summary>
        /// Employee data from web api.
        /// </summary>
        [JsonProperty("data")]
        public Employee Data { get; set; }
    }
}