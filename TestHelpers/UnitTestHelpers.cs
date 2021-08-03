using System.Net;
using Employees.Shared.Models;

namespace TestHelpers
{
    /// <summary>
    /// Helper class for unit tests.
    /// </summary>
    public static class UnitTestHelpers
    {
        /// <summary>
        /// Creates dummy employee.
        /// </summary>
        /// <returns>Dummy employee.</returns>
        public static IEmployee GetDummyEmployee()
        {
            return new Employee
            {
                Id = 1,
                Name = "test",
                Email = "email@email.com",
                Gender = "Male",
                Status = "Active",
            };
        }

        /// <summary>
        /// Creates dummy host data.
        /// </summary>
        /// <returns>HostData.</returns>
        public static HostData GetDummyHostData()
        {

            var hostData = new HostData
            {
                Data = (Employee)GetDummyEmployee(),
                Code = HttpStatusCode.OK,
            };

            return hostData;
        }
    }
}