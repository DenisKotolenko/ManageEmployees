using Employees.Shared.Models;

namespace Employees.Formatters
{
    /// <summary>
    /// Class for text formatting of messages.
    /// </summary>
    public class TextFormatter : ITextFormatter
    {
        /// <inheritdoc />
        public string SuccesfullyDeletedEmployeeText(int id)
        {
            return $"Successfully deleted employee with id: {id}";
        }

        /// <inheritdoc />
        public string AddEmployeeText(IEmployee result)
        {
            return $"Employee with id: {result.Id} Successfully added. Full data: Name: {result.Name}, Email: {result.Email}, Gender: {result.Gender}, Status: {result.Status}";
        }

        /// <inheritdoc />
        public string NoBackPageText(int currentPage)
        {
            return $"There is no back page. Currently on page: {currentPage}";
        }

        /// <inheritdoc />
        public string NoNextPageText(int maximumPages)
        {
            return $"There is no next page. Maximum number of pages: {maximumPages}";
        }

        /// <inheritdoc />
        public string GenerateUpdateMessage(int id, IEmployee employee)
        {
            return $"Updated employee with id: {id} Updated Employee from web api: Name: {employee.Name}, Email: {employee.Email}, Status: {employee.Status}, Gender: {employee.Gender}";
        }
    }
}