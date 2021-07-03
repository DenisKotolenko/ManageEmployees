using System;
using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Employee class for employee object JSON serialization / deserialization.
    /// NOTE: This class is used for whole solution as main Employee class.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id of employee.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of employee.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email of employee.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gender of employee.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Employment status of employee.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Employee creation date and time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Employee update date and time.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty("message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Field with error.
        /// </summary>
        [JsonProperty("field")]
        public string ErrorField { get; set; }
    }
}
