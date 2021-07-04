using Newtonsoft.Json;

namespace Employees.Shared.Models
{
    public class MetaData
    {
        /// <summary>
        /// Pagination meta data.
        /// </summary>
        [JsonProperty("pagination")]
        public PaginationMetaData PaginationData { get; set; }
    }
}
