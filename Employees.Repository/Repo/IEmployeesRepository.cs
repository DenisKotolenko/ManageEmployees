#region Copyright Vanderlande Industries B.V. 2021

// Copyright (c) 2021 Vanderlande Industries.
// All rights reserved.
// 
// The copyright to the computer program(s) herein is the property of
// Vanderlande Industries. The program(s) may be used and/or copied
// only with the written permission of the owner or in accordance with
// the terms and conditions stipulated in the contract under which the
// program(s) have been supplied.
#endregion
using System.Net.Http;
using System.Threading.Tasks;
using Employees.Shared.Models;

namespace Employees.Repository.Repo
{
    public interface IEmployeesRepository
    {
        Task<IEmployee> AddEmployeeToWebApiAsync(StringContent stringContent);

        Task<IEmployee> UpdateEmployeeToWebApiAsync(string putUrl, StringContent stringContent);

        Task DeleteEmployeeFromWebApiAsync(string deleteUrl);

        Task<IHostDataList> ViewEmployeesByCriteriaWebApiAsync(string getByCriteriaUrl);

        Task<IEmployee> FindEmployeeByIdWebApiAsyncTask(string getByIdUrl);
    }
}