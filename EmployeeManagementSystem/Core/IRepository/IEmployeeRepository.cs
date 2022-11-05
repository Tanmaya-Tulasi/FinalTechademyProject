using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
    interface IEmployeeRepository
    {
        public  Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployee();

    }
}
