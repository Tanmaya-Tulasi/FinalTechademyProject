using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [EnableCors("AllowOrigin")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
      
    
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                var employee =await employeeRepository.GetAllEmployee();
                return Ok(employee);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("{ID:int}")]
        public async Task<IActionResult> GetEmployeeById(int ID)
        {
            try
            {
                var result = await employeeRepository.GetById(ID);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async  Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                var emp = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetAllEmployees), new
                {
                    id = emp.ID
                }, emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                var employee =await employeeRepository.DeleteEmployee(id);

                return Ok("Deleted Successfully");

            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, EmployeeModel employee)
        {
            try
            {
                //var emp = await employeeRepository.UpdateEmployee(id,employee);
                //return CreatedAtAction(nameof(GetAllEmployees), new
                //{
                //    id = emp.ID
                //}, emp);

                var result =await employeeRepository.UpdateEmployee(id, employee);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
