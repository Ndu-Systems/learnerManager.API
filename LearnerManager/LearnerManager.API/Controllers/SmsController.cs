using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.SMS;
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
        private readonly ISmsService _smsService;
      
        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
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
                    var message = _smsService.SendSms(model);
                    if (message == null)
                    {
                        return BadRequest("Sending message resulted in an error, please contact system administrator!");
                    }
                    return Ok(message);
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
