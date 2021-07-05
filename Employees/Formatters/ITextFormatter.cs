using Employees.Shared.Models;

namespace Employees.Formatters
{
    public interface ITextFormatter
    {
        string SuccesfullyDeletedEmployeeText(int id);
        string AddEmployeeText(IEmployee result);
        string NoBackPageText(int currentPage);
        string NoNextPageText(int maximumPages);
        string GenerateUpdateMessage(int id, IEmployee employee);
    }
}