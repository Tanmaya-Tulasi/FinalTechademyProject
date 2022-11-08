using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]

    public class WorkingHourController : Controller
    {
        private readonly IWorkingHourRepository hourRepository;

        public WorkingHourController(IWorkingHourRepository _hourRepository)
        {
            hourRepository = _hourRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkingHours()
        {
            try
            {
                var hours = await hourRepository.GetWorkingHours();
                return Ok(hours);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWorkingHoursByID(int id)
        {
            try
            {
                var hours = await hourRepository.GetWorkingHoursById(id);
                return Ok(hours);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddHours([FromBody] WorkingHourModel hourModel)
        {
            try
            {
                var result = await hourRepository.AddHours(hourModel);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateHours([FromRoute] int id, WorkingHourModel hours)
        {
            try
            {
                var result = await hourRepository.UpdateWorkingHours(id, hours);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteHours(int id)
        {
            try
            {
                var result = await hourRepository.DeleteHours(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
