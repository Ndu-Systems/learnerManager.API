using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnerManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LearnersController : ControllerBase
    {
        private readonly ILearnerService _learnerService;
        private readonly IParentLearnerService _parentLearnerService;
 
        public LearnersController(ILearnerService learnerService, 
            IParentLearnerService parentLearnerService)
        {
            _learnerService = learnerService;
            _parentLearnerService = parentLearnerService;
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
        public async Task<IActionResult> Post([FromBody] LearnerModel model)
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
                    return Ok(_learnerService.CreateLearner(model));
                }
                return BadRequest("An error has occurred, please contact system administrator!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LearnerModel model)
        {
           
            try
            {
                var userId = User.Identity.Name;
                if (userId != null)
                {
                    model.ModifyUserId = Guid.Parse(userId);
                    var result = _learnerService.UpdateLearner(id, model);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                return BadRequest("An error has occurred, please contact system administrator!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}/parents")]
        public IActionResult GetParentsForLearner(Guid id)
        {
            var result = _parentLearnerService.GetParentsForLearner(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost("{id}/parents")]
        public async Task<IActionResult> LinkParentsToLearner([FromBody]List<ParentLearnerModel> models, Guid id)
        {
            try
            {
                 foreach (var model in models)
                {
                    //model.CreateUserId = Guid.Parse(currentUser.Id);
                    model.CreateDate = DateTime.Now;
                    //model.ModifyUserId = Guid.Parse(currentUser.Id);
                    model.ModifyDate = DateTime.Now;
                }
                var result = _parentLearnerService.AddParentsForLearner(models, id);
                if (result == null) return BadRequest("An error has occurred, please contact system administrator!");
                return Ok(result);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}