using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for receiving JSON data from web api.
    /// </summary>
    public class HostDataList
    {
        /// <summary>
        /// HTTP status code from web api.
        /// </summary>
        [JsonProperty("code")]
        public HttpStatusCode Code { get; set; }
        
        /// <summary>
        /// List of employees from web api.
        /// </summary>
        [JsonProperty("data")]
        public List<Employee> EmployeeDataList { get; set; }
    }
}

