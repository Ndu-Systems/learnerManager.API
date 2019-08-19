using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Twillo;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnerManager.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioService _twilioService;
        private readonly UserManager<User> _userManager;
        public SmsController(ITwilioService twilioService, UserManager<User> userManager)
        {
            _twilioService = twilioService;
            _userManager = userManager;
        }
         
        [HttpPost("send-sms")]
        public async Task<IActionResult> Post([FromBody]SmsModel model)
        {
            try
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentUser != null)
                {
                    model.CreateUserId = Guid.Parse(currentUser.Id);
                    model.CreateDate = DateTime.Now;
                    model.ModifyUserId = Guid.Parse(currentUser.Id);
                    model.ModifyDate = DateTime.Now;
                    var smseModel = _twilioService.SendSms(model);
                    if (smseModel == null)
                    {
                        return BadRequest("Sending message resulted in an error, please contact system administrator!");
                    }
                    return Ok(smseModel);
                }
                return BadRequest("An error has occurred, please contact system administrator!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
