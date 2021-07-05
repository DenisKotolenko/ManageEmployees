using System;

namespace Employees.Shared.Models
{
    /// <summary>
    /// Employee interface.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Id of employee.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Name of employee.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Email of employee.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gender of employee.
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// Employment status of employee.
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Employee creation date and time.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Employee update date and time.
        /// </summary>
        DateTime Updated { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Field with error.
        /// </summary>
        string ErrorField { get; set; }
    }
}