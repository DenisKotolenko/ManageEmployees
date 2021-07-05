using Employees.Providers;
using NUnit.Framework;

namespace Employees.UnitTest.Providers
{
    /// <summary>
    /// Unit test class for PageProvider class.
    /// </summary>
    [TestFixture]
    public class PageProviderTest
    {
        private const string CurrentPage = "1";
        private const string MaximumNumberOfPages = "10";
        private IPageProvider _pageProvider;

        [SetUp]
        public void SetUp()
        {
            _pageProvider = new PageProvider();
            _pageProvider.SetCurrentPageAndLimit(CurrentPage, MaximumNumberOfPages);
        }

        [Test]
        public void GetCurrentPageTest()
        {
            // Prepare
            // Act
            int result = _pageProvider.GetCurrentPage();

            // Assert
            Assert.AreEqual(int.Parse(CurrentPage), result);
        }

        [Test]
        public void GetMaximumPageTest()
        {
            // Prepare
            // Act
            int result = _pageProvider.GetMaximumNumberOfPages();

            // Assert
            Assert.AreEqual(int.Parse(MaximumNumberOfPages), result);
        }

        [Test]
        public void SetCurrentPageAndLimitTest()
        {
            // Prepare
            var currentPage = 12;
            var maxPage = 22;

            // Act
            _pageProvider.SetCurrentPageAndLimit(currentPage.ToString(), maxPage.ToString());

            // Assert
            Assert.AreEqual(_pageProvider.GetCurrentPage(), currentPage);
            Assert.AreEqual(_pageProvider.GetMaximumNumberOfPages(), maxPage);
        }

        [Test]
        public void GetBackButtonAvailabilityFalseTest()
        {
            // Prepare
            // Act
            bool result = _pageProvider.GetBackButtonAvailability();

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetBackButtonAvailabilityTrueTest()
        {
            // Prepare
            _pageProvider.SetCurrentPageAndLimit("10", string.Empty);

            // Act
            bool result = _pageProvider.GetBackButtonAvailability();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void GetNextButtonAvailabilityTrueTest()
        {
            // Prepare
            // Act
            bool result = _pageProvider.GetNextButtonAvailability();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void GetNextButtonAvailabilityFalseTest()
        {
            // Prepare
            _pageProvider.SetCurrentPageAndLimit(MaximumNumberOfPages, MaximumNumberOfPages);

            // Act
            bool result = _pageProvider.GetNextButtonAvailability();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}