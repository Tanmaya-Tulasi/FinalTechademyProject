using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository desig;

        public DesignationController( IDesignationRepository _designation)
        {
            desig = _designation;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignations()
        {
            try
            {
                var result = await desig.GetDesignations();
                return Ok(result);
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
                var result = await desig.GetDesignationById(ID);
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
        
        public async Task<IActionResult> AddDesignation([FromBody] DesignationModel designation)
        {
            try
            {
                var result = await desig.AddDesignation(designation);
                
                return Ok("Added Successfully");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDesignation([FromRoute] int id, DesignationModel design)
        {
            try
            {
                var designation = await desig.UpdateDesignation(id, design);
                return Ok(designation);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            try
            {
                var result = await desig.DeleteDesignation(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        
    }
}
