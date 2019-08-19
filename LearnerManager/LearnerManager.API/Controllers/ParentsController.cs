using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnerManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;
        private readonly IParentLearnerService _parentLearnerService;
        private readonly UserManager<User> _userManager;
        public ParentsController(IParentService parentService, 
            IParentLearnerService parentLearnerService,
            UserManager<User> userManager)
        {
            _parentService = parentService;
            _parentLearnerService = parentLearnerService;
            _userManager = userManager;
        }
        // GET: api/parents
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_parentService.GetAllPArents());
        }

        // GET api/parents/f55b6e33-bcc4-4a6c-b9ad-0dd6e1f3cd1e
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_parentService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ParentModel model)
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
                    return Ok(_parentService.CreateParent(model));
                }
                return BadRequest("An error has occurred, please contact system administrator!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ParentModel model)
        {
            try
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentUser != null)
                {
                    model.ModifyUserId = Guid.Parse(currentUser.Id);
                    model.ModifyDate = DateTime.Now;
                    var result = _parentService.UpdateParent(id, model);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return null;
                    }
                }

                return BadRequest("An error has occurred, please contact system administrator!");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        [HttpGet("{id}/learners")]
        public IActionResult GetLearnersForParent(Guid id)
        {
            var result = _parentLearnerService.GetLearnersForParent(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("{id}/learners")]
        public async Task<IActionResult> LinkLearnersToParent([FromBody] List<ParentLearnerModel> models, Guid id)
        {
           
            try
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var model in models)
                {
                    model.CreateUserId = Guid.Parse(currentUser.Id);
                    model.CreateDate = DateTime.Now;
                    model.ModifyUserId = Guid.Parse(currentUser.Id);
                    model.ModifyDate = DateTime.Now;
                }
                var result = _parentLearnerService.AddLearnersForParent(models, id);
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
