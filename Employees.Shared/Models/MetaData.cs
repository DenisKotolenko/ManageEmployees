using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for pagination meta data.
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// Pagination meta data.
        /// </summary>
        [JsonProperty("pagination")]
        public PaginationMetaData PaginationData { get; set; }
    }
}