using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Repository.Client;
using Employees.Repository.Repo;
using Employees.Shared.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using TestHelpers;

namespace Employees.Repository.UnitTest
{
    /// <summary>
    /// Employees repository unit test class.
    /// NOTE: TODO: This class is not fully tested. Would need additional work, but can explain logic how to fully test it.
    /// </summary>
    [TestFixture]
    public class EmployeesRepositoryTest
    {
        private readonly IHttpClientProvider _httpClientProvider;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMemoryCache _memoryCache;
        private const string DummyStringContentText = "dummyText";
        private const string DummyUrl = "URL";
        private const string ApplicationJson = "application/json";

        public EmployeesRepositoryTest()
        {
            _httpClientProvider = Substitute.For<IHttpClientProvider>();
            _memoryCache = Substitute.For<IMemoryCache>();
            _employeesRepository = new EmployeesRepository(_httpClientProvider, _memoryCache);
        }

        [Test]
        public async Task AddEmployeeToWebApiAsyncHappyFlowTest()
        {
            // Prepare
            var response = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(UnitTestHelpers.GetDummyHostData()), Encoding.UTF8, ApplicationJson)
            };

            _httpClientProvider.PostAsync(Arg.Any<string>(), Arg.Any<HttpContent>()).Returns(response);
            
            // Act
            IEmployee result = await _employeesRepository.AddEmployeeToWebApiAsync(new StringContent(DummyStringContentText));

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, result.Email);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, result.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, result.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, result.Status);
        }

        [Test]
        public async Task UpdateEmployeeToWebApiAsyncHappyFlowTest()
        {
            // Prepare
            var response = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(UnitTestHelpers.GetDummyHostData()), Encoding.UTF8, ApplicationJson)
            };

            _httpClientProvider.PutAsync(Arg.Any<string>(), Arg.Any<HttpContent>()).Returns(response);

            // Act
            IEmployee result = await _employeesRepository.UpdateEmployeeToWebApiAsync(DummyUrl, new StringContent(DummyStringContentText));

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Email, result.Email);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Name, result.Name);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Gender, result.Gender);
            Assert.AreEqual(UnitTestHelpers.GetDummyEmployee().Status, result.Status);
        }

        [Test]
        public void DeleteEmployeeFromWebApiAsyncHappyFlow()
        {
            // Prepare
            var response = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(UnitTestHelpers.GetDummyHostData()), Encoding.UTF8, ApplicationJson)
            };

            _httpClientProvider.DeleteAsync(Arg.Any<string>()).Returns(response);

            // Act
            // Assert
            Assert.That(async () => await _employeesRepository.DeleteEmployeeFromWebApiAsync(DummyUrl), Throws.Nothing);
            _memoryCache.Received().Dispose();
        }
    }
}
