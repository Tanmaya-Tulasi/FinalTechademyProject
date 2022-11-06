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
        private readonly EmployeeManagementDbContext dbContext;

        public DesignationController(EmployeeManagementDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignations()
        {
            try
            {
                var result =await  dbContext.Designation.ToListAsync();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        
        public async Task<IActionResult> AddDesignation([FromBody] DesignationModel designation)
        {
            try
            {
                var result = await dbContext.Designation.AddAsync(designation);
                await dbContext.SaveChangesAsync();
                return Ok("Added Successfully");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDesignation([FromRoute] int id, DesignationModel desig)
        {
            try
            {
                var designation = await dbContext.Designation.FindAsync(id);
                if (designation == null)
                    return NotFound();
                designation.DepartmentName = desig.DepartmentName;
                designation.DesignationName = desig.DesignationName;
                designation.RoleName = desig.RoleName;
                //designation.EmployeDetails = desig.EmployeDetails;
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
                var result = await dbContext.Designation.FindAsync(id);
                if (result == null)
                    return NotFound();
                 dbContext.Designation.Remove(result);
                await dbContext.SaveChangesAsync();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        
    }
}
