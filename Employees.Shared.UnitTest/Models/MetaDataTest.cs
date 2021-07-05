using Employees.Shared.Models;
using NUnit.Framework;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Test class for meta data class.
    /// </summary>
    [TestFixture]
    public class MetaDataTest
    {
        [Test]
        public void MetaDataGetSetTest()
        {
            // Prepare
            var paginationMetaData = new PaginationMetaData();

            // Act
            var metaData = new MetaData()
            {
                PaginationData = paginationMetaData,
            };

            // Assert
            Assert.AreEqual(paginationMetaData, metaData.PaginationData);
        }
    }
}
