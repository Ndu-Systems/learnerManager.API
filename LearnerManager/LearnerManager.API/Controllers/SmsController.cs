using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Twillo;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnerManager.API.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioService _twilioService;
        
        public SmsController(ITwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        // POST api/accounts/login
        [HttpPost("send-sms")]
        public ActionResult Post([FromBody]SmsModel model)
        {
            var smseModel = _twilioService.SendSms(model);
            if (smseModel == null)
            {
                return BadRequest();
            }
            return Ok(smseModel);
        }
    }
}
