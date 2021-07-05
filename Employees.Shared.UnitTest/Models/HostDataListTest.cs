using System.Collections.Generic;
using System.Net;
using Employees.Shared.Models;
using NUnit.Framework;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Test class for host data list.
    /// </summary>
    [TestFixture]
    public class HostDataListTest
    {
        [Test]
        public void HostDataListGetSetTest()
        {
            // Prepare
            var metaData = new MetaData();
            var employee = (Employee) TestHelpers.UnitTestHelpers.GetDummyEmployee();
            var employees = new List<Employee>()
            {
                employee,
            };

            // Act
            var hostDataList = new HostDataList()
            {
                Code = HttpStatusCode.Accepted,
                EmployeeDataList = employees,
                MetaData = metaData,
            };

            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, hostDataList.Code);
            Assert.AreEqual(metaData, hostDataList.MetaData);
            CollectionAssert.AreEqual(employees, hostDataList.EmployeeDataList);
        }
    }
}
