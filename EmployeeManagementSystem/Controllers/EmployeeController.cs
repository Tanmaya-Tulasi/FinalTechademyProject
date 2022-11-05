using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(EmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var employee = employeeRepository.GetAllEmployee();
                return Ok(employee);
            }
            catch(Exception e)
            {
                return Ok(e);
            }
        }
    }
}
