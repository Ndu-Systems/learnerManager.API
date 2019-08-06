using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/login
        [HttpGet("login")]
        public IActionResult Post([FromBody]LoginModel model)
        {
            return Ok(_userService.LoginUser(model));
        }
         
    }
}
