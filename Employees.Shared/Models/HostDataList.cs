using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for receiving JSON data from web api.
    /// </summary>
    public class HostDataList : IHostDataList
    {
        ///<inheritdoc/>
        [JsonProperty("code")]
        public HttpStatusCode Code { get; set; }

        ///<inheritdoc/>
        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }

        ///<inheritdoc/>
        [JsonProperty("data")]
        public List<Employee> EmployeeDataList { get; set; }
    }
}