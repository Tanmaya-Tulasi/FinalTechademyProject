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
    public class PaymentRulesController : Controller
    {
        private readonly IPaymentRulesRepository paymentRulesRepository;

        public PaymentRulesController(IPaymentRulesRepository paymentRulesRepository)
        {
            this.paymentRulesRepository = paymentRulesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentRules()
        {
            try
            {
                var result = await paymentRulesRepository.GetAllPaymentRules();
                if(result!= null)
                {
                    return Ok(result);
                }
                return NotFound("No Employees Found");

            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            try
            {
                var result = await paymentRulesRepository.GetById(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddPaymentRule([FromBody] PaymentRulesModel rule)
        {
            try
            {
                var result = await paymentRulesRepository.AddPaymentRule(rule);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePayment([FromRoute] int id , PaymentRulesModel rule)
        {
            try
            {
                var result = await paymentRulesRepository.UpdateRules(id, rule);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            try
            {
                var result = await paymentRulesRepository.DeleteRule(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
