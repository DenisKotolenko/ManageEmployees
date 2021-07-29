using Employees.Shared.Models;
using NUnit.Framework;

namespace Employees.Shared.UnitTest.Models
{
    /// <summary>
    /// Class for testing Employee class.
    /// </summary>
    [TestFixture]
    public class EmployeeTest
    {
        private readonly IEmployee _dummyEmployee;
        private const string ErrorMessage = "dummyError";
        private const string ErrorField = "dummyField";

        public EmployeeTest()
        {
            _dummyEmployee = TestHelpers.UnitTestHelpers.GetDummyEmployee();
        }

        [Test]
        public void EmployeeSetGetTest()
        {
            // Prepare
            // Act
            var createEmployee = new Employee
            {
                Id = _dummyEmployee.Id,
                Name = _dummyEmployee.Name,
                Gender = _dummyEmployee.Gender,
                Status = _dummyEmployee.Status,
                ErrorMessage = ErrorMessage,
                Email = _dummyEmployee.Email,
                ErrorField = ErrorField,
            };
            
            // Assert
            Assert.AreEqual(_dummyEmployee.Id, createEmployee.Id);
            Assert.AreEqual(_dummyEmployee.Name, createEmployee.Name);
            Assert.AreEqual(_dummyEmployee.Gender, createEmployee.Gender);
            Assert.AreEqual(_dummyEmployee.Status, createEmployee.Status);
            Assert.AreEqual(_dummyEmployee.Email, createEmployee.Email);
            Assert.AreEqual(ErrorField, createEmployee.ErrorField);
            Assert.AreEqual(ErrorMessage, createEmployee.ErrorMessage);
        }
    }
}
