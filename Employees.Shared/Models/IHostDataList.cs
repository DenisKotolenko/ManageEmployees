using System.Collections.Generic;
using System.Net;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Interface for Host data list.
    /// </summary>
    public interface IHostDataList
    {
        /// <summary>
        /// HTTP status code from web api.
        /// </summary>
        HttpStatusCode Code { get; set; }

        /// <summary>
        /// Meta data from web api.
        /// </summary>
        MetaData MetaData { get; set; }

        /// <summary>
        /// List of employees from web api.
        /// </summary>
        List<Employee> EmployeeDataList { get; set; }
    }
}
