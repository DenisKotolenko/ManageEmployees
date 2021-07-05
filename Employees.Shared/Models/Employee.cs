using System;
using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Employee class for employee object JSON serialization / deserialization.
    /// NOTE: This class is used for whole solution as main Employee class.
    /// </summary>
    public class Employee : IEmployee
    {
        ///<inheritdoc/>
        [JsonProperty("id")]
        public int Id { get; set; }

        ///<inheritdoc/>
        [JsonProperty("name")]
        public string Name { get; set; }

        ///<inheritdoc/>
        [JsonProperty("email")]
        public string Email { get; set; }

        ///<inheritdoc/>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        ///<inheritdoc/>
        [JsonProperty("status")]
        public string Status { get; set; }

        ///<inheritdoc/>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        ///<inheritdoc/>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        ///<inheritdoc/>
        [JsonProperty("message")]
        public string ErrorMessage { get; set; }

        ///<inheritdoc/>
        [JsonProperty("field")]
        public string ErrorField { get; set; }
    }
}