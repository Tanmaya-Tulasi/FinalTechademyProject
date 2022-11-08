using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class RequestLeaveController : Controller
    {
        private readonly IRequestLeaveRepository requestLeaveRepository;
        public RequestLeaveController(IRequestLeaveRepository requestLeaveRepository)
        {
            this.requestLeaveRepository = requestLeaveRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllLeaves()
        {
            return Ok(await requestLeaveRepository.GetAllLeaves());
        }
        [HttpPost]
        public async Task<ActionResult<RequestLeave>> AddLeave(RequestLeave requestLeave)
        {
            var create = await requestLeaveRepository.AddLeave(requestLeave);
            return CreatedAtAction(nameof(GetAllLeaves), new { id = create.LeaveID }, create);

        }


        [HttpPut]
        public async Task<ActionResult<RequestLeave>> UpdateLeave(int LeaveID, RequestLeave requestLeave)
        {
            try
            {
                if (LeaveID != requestLeave.LeaveID)
                    return BadRequest("Employee ID mismatch");
                var update = await requestLeaveRepository.GetLeave(LeaveID);
                if (update == null)
                {
                    return NotFound("Employee ID not Found");
                }
                return await requestLeaveRepository.UpdateLeave(LeaveID, requestLeave);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{LeaveID:int}")]
        public async Task<ActionResult<RequestLeave>> GetLeave(int LeaveID)
        {
            try
            {
                var result = await requestLeaveRepository.GetLeave(LeaveID);
                if (result == null) return NotFound();
                return result;

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("{LeaveID:int}")]
        public async Task<ActionResult> DeleteLeave(int LeaveID)
        //public async Task<ActionResult<RequestLeave>> DeleteLeave(int LeaveID)
        {

            try
            {
                var result = await requestLeaveRepository.GetLeave(LeaveID);

                if (result == null) return NotFound($"Employee with LeaveID={LeaveID} not found");
                var l = await requestLeaveRepository.DeleteLeave(LeaveID);
                return Ok(l);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
