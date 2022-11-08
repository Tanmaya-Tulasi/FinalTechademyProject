using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly EmployeeManagementDbContext _userContext;

        public AccountController(IConfiguration configuration, EmployeeManagementDbContext userContext)
        {
            _config = configuration;
            _userContext = userContext;
        }
        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult CreateUser(RegisterModel user)
        {
            if (_userContext.Register.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already Existed");
            }
            _userContext.Register.Add(user);
            _userContext.SaveChanges();

            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpPost("loginUser")]
        public IActionResult LoginUser(LoginModel login)
        {
            var useravailable = _userContext.Register.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
            if (useravailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                   useravailable.UserID.ToString(),
                   useravailable.FirstName,
                   useravailable.LastName,
                   useravailable.Email,
                   useravailable.MobileNumber,
                   useravailable.Gender

                ));
            }
            return Ok("Failure");
        }
    }
}
