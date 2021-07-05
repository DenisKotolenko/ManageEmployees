namespace Employees.Providers
{
    public interface IPageProvider
    {
        void SetCurrentPageAndLimit(string page, string limit);
        int GetCurrentPage();
        int GetMaximumNumberOfPages();
        bool GetBackButtonAvailability();
        bool GetNextButtonAvailability();
    }
}