using System.Collections.Generic;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Interface for search criteria.
    /// </summary>
    public interface ICriteria
    {
        /// <summary>
        /// Id for search criteria.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Name for search criteria.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gender for search criteria.
        /// </summary>
        string Gender { get; }
        /// <summary>
        /// Status for search criteria.
        /// </summary>
        string Status { get; }
        /// <summary>
        /// Page for search criteria.
        /// </summary>
        string Page { get; }
        /// <summary>
        /// Creates criteria from attributes.
        /// </summary>
        /// <returns>Criteria dictionary. Used for search.</returns>
        Dictionary<string, string> CreateCriteria();
    }
}
