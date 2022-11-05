using EmployeeManagementSystem.Core.IRepository;
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
        public List<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                var employee = employeeRepository.GetAllEmployee();
                return (employee);
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        public  IActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                var emp = employeeRepository.AddEmployee(employee);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                var employee = employeeRepository.DeleteEmployee(id);

                return Ok(employee);

            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute] int id, EmployeeModel employee)
        {
            try
            {
                var result = employeeRepository.UpdateEmployee(id, employee);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
