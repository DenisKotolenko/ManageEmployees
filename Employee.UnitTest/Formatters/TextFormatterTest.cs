using Employees.Formatters;
using Employees.Shared.Models;
using NSubstitute;
using NUnit.Framework;
using TestHelpers;

namespace Employees.UnitTest.Formatters
{
    /// <summary>
    /// Unit test class for TextFormatter class.
    /// </summary>
    [TestFixture]
    public class TextFormatterTest
    {
        private ITextFormatter _textFormatter;
        private IEmployee _dummyEmployee;
        private readonly int Zero = 0;
        private readonly int One = 1;

        [SetUp]
        public void SetUp()
        {
            _textFormatter = new TextFormatter();
            _dummyEmployee = UnitTestHelpers.GetDummyEmployee();
        }

        [Test]
        public void SuccesfullyDeletedEmployeeTextTest()
        {
            // Prepare
            int id = Zero;
            var expectedText = $"Successfully deleted employee with id: {id}";

            // Act
            string result = _textFormatter.SuccesfullyDeletedEmployeeText(id);

            // Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void AddEmployeeTextTest()
        {
            // Prepare
            IEmployee mock = PrepareEmployeeMock();
            var expectedText = $"Employee with id: {_dummyEmployee.Id} Successfully added. Full data: Name: {_dummyEmployee.Name}, Email: {_dummyEmployee.Email}, Gender: {_dummyEmployee.Gender}, Status: {_dummyEmployee.Status}, Created: {_dummyEmployee.Created}, Updated: {_dummyEmployee.Updated} ";

            // Act
            string result = _textFormatter.AddEmployeeText(mock);

            // Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void NoBackPageTest()
        {
            // Prepare
            int currentPage = One;
            var expectedText = $"There is no back page. Currently on page: {currentPage}";

            // Act
            string result = _textFormatter.NoBackPageText(currentPage);

            // Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void NoNextPageTextTest()
        {
            // Prepare
            int maximumPages = One;
            var expectedText = $"There is no next page. Maximum number of pages: {maximumPages}";

            // Act
            string result = _textFormatter.NoNextPageText(maximumPages);

            // Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void GenerateUpdateMessageTest()
        {
            // Prepare
            IEmployee mock = PrepareEmployeeMock();
            int id = One;
            var expectedText = $"Updated employee with id: {id} Updated Employee from web api: Name: {_dummyEmployee.Name}, Email: {_dummyEmployee.Email}, Status: {_dummyEmployee.Status}, Gender: {_dummyEmployee.Gender}, Created: {_dummyEmployee.Created.ToLongTimeString()}, Updated: {_dummyEmployee.Updated.ToLongTimeString()}";

            // Act
            string result = _textFormatter.GenerateUpdateMessage(id, mock);

            // Assert
            Assert.AreEqual(expectedText, result);
        }

        private IEmployee PrepareEmployeeMock()
        {
            var sub = Substitute.For<IEmployee>();
            sub.Id.Returns(_dummyEmployee.Id);
            sub.Name.Returns(_dummyEmployee.Name);
            sub.Email.Returns(_dummyEmployee.Email);
            sub.Status.Returns(_dummyEmployee.Status);
            sub.Gender.Returns(_dummyEmployee.Gender);
            sub.Created.Returns(_dummyEmployee.Created);
            sub.Updated.Returns(_dummyEmployee.Updated);

            return sub;
        }
    }
}