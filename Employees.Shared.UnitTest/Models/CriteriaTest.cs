using System.Collections.Generic;
using Employees.Shared.Models;
using NUnit.Framework;
using TestHelpers;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Class for unit testing criteria.
    /// </summary>
    [TestFixture]
    public class CriteriaTest
    {
        private IEmployee Employee => UnitTestHelpers.GetDummyEmployee();

        [Test]
        public void GetersAndConstructorTest()
        {
            // Prepare
            // Act
            var result = new Criteria(Employee.Id.ToString(), Employee.Name, Employee.Gender, Employee.Status, Constants.Constants.FirstPage);

            // Assert
            Assert.AreEqual(Employee.Id.ToString(), result.Id);
            Assert.AreEqual(Employee.Name, result.Name);
            Assert.AreEqual(Employee.Status, result.Status);
            Assert.AreEqual(Employee.Gender, result.Gender);
            Assert.AreEqual(Constants.Constants.FirstPage, result.Page);
        }

        [Test]
        public void CreateCriteriaTest()
        {
            // Prepare
            var expectedResult = new Dictionary<string, string>
            {
                { "Id", Employee.Id.ToString() },
                { "Name", Employee.Name },
                { "Gender", Employee.Gender },
                { "Status", Employee.Status },
                { "Page", Constants.Constants.FirstPage }
            };
            var criteria = new Criteria(Employee.Id.ToString(), Employee.Name, Employee.Gender, Employee.Status, Constants.Constants.FirstPage);

            // Act
            Dictionary<string, string> result = criteria.CreateCriteria();

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
