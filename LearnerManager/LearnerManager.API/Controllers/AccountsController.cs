using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }       

        // POST api/accounts/login
        [HttpPost("login")]       
        public ActionResult Post([FromBody]LoginModel model)
        {
            var result = _userService.LoginUser(model);
             return Ok(result.Result);
        } 
    }
}