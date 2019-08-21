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
      
        public SmsController(ITwilioService twilioService, UserManager<User> userManager)
        {
            _twilioService = twilioService;
            
        }
         
        [HttpPost("send-sms")]
        public async Task<IActionResult> Post([FromBody]SmsModel model)
        {
            try
            {
                var userId = User.Identity.Name;
                if (userId != null)
                {
                    model.CreateUserId = Guid.Parse(userId);
                    model.CreateDate = DateTime.Now;
                    model.ModifyUserId = Guid.Parse(userId);
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
