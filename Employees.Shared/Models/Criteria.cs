using System.Collections.Generic;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Class for search criteria.
    /// </summary>
    public class Criteria : ICriteria
    {
        ///<inheritdoc/>
        public string Id { get; }
        ///<inheritdoc/>
        public string Name { get; }
        ///<inheritdoc/>
        public string Gender { get; }
        ///<inheritdoc/>
        public string Status { get; }
        ///<inheritdoc/>
        public string Page { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Id for criteria.</param>
        /// <param name="name">Name for criteria.</param>
        /// <param name="gender">Gender for criteria.</param>
        /// <param name="status">Status for criteria.</param>
        /// <param name="page">Page for criteria.</param>
        public Criteria(string id, string name, string gender, string status, string page)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Status = status;
            Page = page;
        }

        ///<inheritdoc/>
        public Dictionary<string, string> CreateCriteria()
        {
            var criteriaDictionary = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(Page))
            {
                criteriaDictionary.Add(nameof(HostDataList.MetaData.PaginationData.Page), Page);
            }
            if (!string.IsNullOrWhiteSpace(Id))
            {
                criteriaDictionary.Add(nameof(Employee.Id), Id);
            }
            if (!string.IsNullOrWhiteSpace(Name))
            {
                criteriaDictionary.Add(nameof(Employee.Name), Name);
            }
            if (!string.IsNullOrEmpty(Gender))
            {
                criteriaDictionary.Add(nameof(Employee.Gender), Gender);
            }
            if (!string.IsNullOrEmpty(Status))
            {
                criteriaDictionary.Add(nameof(Employee.Status), Status);
            }

            return criteriaDictionary;
        }
    }
}