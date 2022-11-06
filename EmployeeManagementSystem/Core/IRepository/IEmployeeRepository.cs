using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
  public  interface IEmployeeRepository
    {
        public Task<List<EmployeeDTO>> GetAllEmployee();
        public Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        public Task<EmployeeModel> UpdateEmployee(int id, EmployeeModel employee);
        public Task<EmployeeModel> DeleteEmployee(int id);
        public Task<EmployeeModel> GetById(int id);


    }
}
