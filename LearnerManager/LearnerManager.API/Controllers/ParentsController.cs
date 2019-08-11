﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;
        private readonly IParentLearnerService _parentLearnerService;
        public ParentsController(IParentService parentService, IParentLearnerService parentLearnerService)
        {
            _parentService = parentService;
            _parentLearnerService = parentLearnerService;
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
        public IActionResult Post([FromBody]ParentModel model)
        {
            return Ok(_parentService.CreateParent(model));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ParentModel model)
        {
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

        [HttpGet("{id}/learners")]
        public IActionResult GetLearnersForParent(Guid id)
        {
            var result = _parentLearnerService.GetLearnersForParent(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("{id}/learners")]
        public IActionResult LinkLearnersToParent([FromBody] List<ParentLearnerModel> models, Guid id)
        {
            var result = _parentLearnerService.AddLearnersForParent(models, id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
