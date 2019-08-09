using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }
        // GET: api/assets
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_assetService.GetAll());
        }

        // GET api/assets/f55b6e33-bcc4-4a6c-b9ad-0dd6e1f3cd1e
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_assetService.GetById(id));
        }

        // POST api/assets
        [HttpPost]
        public IActionResult Post([FromBody]AssetModel model)
        {
            return Ok(_assetService.CreateAsset(model));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]AssetModel model)
        {
            var result = _assetService.UpdateAsset(id, model);
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

      
    }
}
