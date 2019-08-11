using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnersController : ControllerBase
    {
        private readonly ILearnerService _learnerService;

        public LearnersController(ILearnerService learnerService)
        {
            _learnerService = learnerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_learnerService.GetAllLearners());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_learnerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LearnerModel model)
        {
            return Ok(_learnerService.CreateLearner(model));
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LearnerModel model)
        {
            var result = _learnerService.UpdateLearner(id, model);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}