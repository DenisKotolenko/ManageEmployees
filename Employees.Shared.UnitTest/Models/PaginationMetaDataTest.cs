using Employees.Shared.Models;
using NUnit.Framework;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Test class for pagination meta data class.
    /// </summary>
    [TestFixture]
    class PaginationMetaDataTest
    {
        private const int One = 1;

        [Test]
        public void PaginationMetadataGetSetTest()
        {
            // Prepare
            // Act
            var paginationMetaData = new PaginationMetaData()
            {
                Total = One,
                Page = One,
                Pages = One,
                Limit = One,
            };

            // Assert
            Assert.AreEqual(One, paginationMetaData.Total);
            Assert.AreEqual(One, paginationMetaData.Pages);
            Assert.AreEqual(One, paginationMetaData.Page);
            Assert.AreEqual(One, paginationMetaData.Limit);
        }

 
    }
}
