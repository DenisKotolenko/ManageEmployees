using Employees.Shared.Constants;

namespace Employees.Providers
{
    /// <summary>
    /// Class for page provider. Holds information about data grid page.
    /// </summary>
    public class PageProvider : IPageProvider
    {
        private int _currentPage;
        private int _maximumNumberOfPages;

        /// <summary>
        /// Sets current page and maximum number of pages.
        /// </summary>
        /// <param name="page">Current page.</param>
        /// <param name="limit">Maximum number of pages.</param>
        public void SetCurrentPageAndLimit(string page, string limit)
        {
            int.TryParse(page, out int parsedPage);
            int.TryParse(limit, out int parsedLimit);

            _currentPage = parsedPage;
            _maximumNumberOfPages = parsedLimit;
        }

        /// <summary>
        /// Gets current page.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPage()
        {
            return _currentPage;
        }

        /// <summary>
        /// Gets maximum number of pages.
        /// </summary>
        /// <returns></returns>
        public int GetMaximumNumberOfPages()
        {
            return _maximumNumberOfPages;
        }

        /// <summary>
        /// Gets availability of back button.
        /// </summary>
        /// <returns></returns>
        public bool GetBackButtonAvailability()
        {
            return !string.IsNullOrEmpty(_currentPage.ToString()) && _currentPage.ToString() != Constants.FirstPage;
        }

        /// <summary>
        /// Gets availability of next button.
        /// </summary>
        /// <returns></returns>
        public bool GetNextButtonAvailability()
        {
            return _currentPage < _maximumNumberOfPages;
        }
    }
}