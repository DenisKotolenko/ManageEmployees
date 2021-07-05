using System.Net;
using Employees.Shared.Models;
using NUnit.Framework;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Class for testing host data class.
    /// </summary>
    [TestFixture]
    public class HostDataTest
    {
        [Test]
        public void HostDataGetSetTest()
        {
            // Prepare
            var metaData = new MetaData();
            var employee = (Employee) TestHelpers.UnitTestHelpers.GetDummyEmployee();

            // Act
            var hostData = new HostData
            {
                Code = HttpStatusCode.Accepted,
                Data = employee,
                MetaData = metaData,
            };

            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, hostData.Code);
            Assert.AreEqual(employee, hostData.Data);
            Assert.AreEqual(metaData, hostData.MetaData);
        }
    }
}
