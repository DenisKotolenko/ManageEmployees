using System;
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
                Created = new DateTime(2000, 1, 1),
                Updated = new DateTime(2000, 1, 1),
            };
        }
    }
}