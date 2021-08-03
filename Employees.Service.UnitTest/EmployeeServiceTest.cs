using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Repository.Repo;
using Employees.Shared.Constants;
using Employees.Shared.Models;
using NSubstitute;
using NUnit.Framework;
using TestHelpers;

namespace Employees.Service.UnitTest
{
    /// <summary>
    /// Class for unit testing EmployeeService.
    /// </summary>
    [TestFixture]
    public class EmployeeServiceTest
    {
        private const int One = 1;
        private readonly IEmployeesRepository _employeesRepository;
        private IEmployeeService _employeeService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EmployeeServiceTest()
        {
            _employeesRepository = Substitute.For<IEmployeesRepository>();
            _employeeService = new EmployeeService(_employeesRepository);
        }

        [Test]
        public void ConstructorTest()
        {
            // Prepare
            // Act
            // Assert
            _employeeService = new EmployeeService(_employeesRepository);
        }

        [Test]
        public async Task GetEmployeeByIdFromWebApiAsyncTest()
        {
            // Prepare
            const int id = 0;
            _employeesRepository.FindEmployeeByIdWebApiAsyncTask($"{Constants.BaseHostAdress}{Constants.SlashHttpDelimeter}{id}").Returns(UnitTestHelpers.GetDummyEmployee());

            // Act
            IEmployee result = await _employeeService.GetEmployeeByIdFromWebApiAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, result.Email);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, result.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, result.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, result.Status);
        }

        [Test]
        public async Task AddEmployeeToWebApiAsyncTest()
        {
            // Prepare
            _employeesRepository.AddEmployeeToWebApiAsync(Arg.Any<StringContent>()).Returns(UnitTestHelpers.GetDummyEmployee());
            
            // Act
            IEmployee result = await _employeeService.AddEmployeeToWebApiAsync(UnitTestHelpers.GetDummyEmployee());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, result.Email);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, result.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, result.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, result.Status);
        }

        [Test]
        public async Task UpdateEmployeeToWebApiAsyncTest()
        {
            // Prepare
            const int id = 0;
            _employeesRepository.UpdateEmployeeToWebApiAsync(Arg.Any<string>(), Arg.Any<StringContent>()).Returns(UnitTestHelpers.GetDummyEmployee());

            // Act
            IEmployee result = await _employeeService.UpdateEmployeeToWebApiAsync(UnitTestHelpers.GetDummyEmployee(), id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, result.Email);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, result.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, result.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, result.Status);
        }

        [Test]
        public async Task DeleteEmployeeFromWebApiAsyncTest()
        {
            // Prepare
            const int id = 0;
            await _employeesRepository.DeleteEmployeeFromWebApiAsync(Arg.Any<string>());

            // Act
            // Assert
            Assert.That(async () => await _employeeService.DeleteEmployeeFromWebApiAsync(id), Throws.Nothing);
        }

        [Test]
        public async Task ViewEmployeesByCriteriaFromWebApiAsyncTest()
        {
            // Prepare
            _employeesRepository.ViewEmployeesByCriteriaWebApiAsync(Arg.Any<string>()).Returns(CreateDummyHostList());
            var dictionary = new Dictionary<string, string>()
            {
                { string.Empty, string.Empty },
            };

            // Act
            IHostDataList result = await _employeeService.ViewEmployeesByCriteriaFromWebApiAsync(dictionary);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(CreateDummyHostList().Code, result.Code);
            Assert.AreEqual(One, result.EmployeeDataList.Count);
            Employee resultEmployee = result.EmployeeDataList.First();
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, resultEmployee.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, resultEmployee.Status);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, resultEmployee.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, resultEmployee.Email);
        }

        [Test]
        public async Task CheckIfRestApiIsOnlineTest()
        {
            // Prepare
            await _employeesRepository.ViewEmployeesByCriteriaWebApiAsync(Arg.Any<string>());

            // Act
            // Assert
            Assert.That(async () => await _employeeService.CheckIfRestApiIsOnline(), Throws.Nothing);
        }

        /// <summary>
        /// NOTE: TODO: This test is not complete! It needs to contain all combinations of exceptions that could happen.
        /// </summary>
        [Test]
        public void ExceptionsTest()
        {
            // Prepare
            var dictionary = new Dictionary<string, string>()
            {
                { string.Empty, string.Empty },
            };

            // Act
            // Assert
            Assert.ThrowsAsync<Exception>(async () => await _employeeService.GetEmployeeByIdFromWebApiAsync(Arg.Any<int>()));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _employeeService.AddEmployeeToWebApiAsync(null));
            Assert.ThrowsAsync<Exception>(async () => await _employeeService.DeleteEmployeeFromWebApiAsync(Arg.Any<int>()));
            Assert.ThrowsAsync<NullReferenceException>(async () => await _employeeService.ViewEmployeesByCriteriaFromWebApiAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _employeeService.UpdateEmployeeToWebApiAsync(null, One));
        }

        public static IHostDataList CreateDummyHostList()
        {
            return new HostDataList
            {
                EmployeeDataList = new List<Employee>()
            {
                (Employee) UnitTestHelpers.GetDummyEmployee()
            },
                Code = HttpStatusCode.OK
            };
        }
    }
}
