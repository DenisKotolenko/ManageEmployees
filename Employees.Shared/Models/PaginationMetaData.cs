using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for pagination data received from web api.
    /// </summary>
    public class PaginationMetaData
    {
        /// <summary>
        /// Total number of results.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        [JsonProperty("pages")]
        public int Pages { get; set; }

        /// <summary>
        /// Current page.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Number of results per page.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}