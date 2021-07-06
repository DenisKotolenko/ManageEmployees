using Employees.Shared.Models;

namespace Employees.Formatters
{
    /// <summary>
    /// Interface for text formatter
    /// </summary>
    public interface ITextFormatter
    {
        /// <summary>
        /// SuccesfullyDeletedEmployeeText method.
        /// </summary>
        /// <param name="id">Id of employee</param>
        /// <returns>Message.</returns>
        string SuccesfullyDeletedEmployeeText(int id);
        
        /// <summary>
        /// AddEmployeeText formatter.
        /// </summary>
        /// <param name="result">Employee.</param>
        /// <returns>Message.</returns>
        string AddEmployeeText(IEmployee result);
        
        /// <summary>
        /// NoBackPageText formatter.
        /// </summary>
        /// <param name="currentPage">Current page.</param>
        /// <returns>Message.</returns>
        string NoBackPageText(int currentPage);
        
        /// <summary>
        /// NoNextPageText formatter.
        /// </summary>
        /// <param name="maximumPages">Maximum number of pages.</param>
        /// <returns>Message.</returns>
        string NoNextPageText(int maximumPages);
        
        /// <summary>
        /// GenerateUpdateMessage formatter.
        /// </summary>
        /// <param name="id">Id of employee.</param>
        /// <param name="employee">Employee.</param>
        /// <returns>Message.</returns>
        string GenerateUpdateMessage(int id, IEmployee employee);
    }
}