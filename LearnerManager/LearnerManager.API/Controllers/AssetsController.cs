using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Contracts.AssetCategory;
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
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IAssetCategoryService _assetCategoryService;
        private readonly UserManager<User> _userManager;
        public AssetsController(IAssetService assetService, 
            IAssetCategoryService assetCategoryService,
            UserManager<User> userManager)
        {
            _assetService = assetService;
            _assetCategoryService = assetCategoryService;
            _userManager = userManager;
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
        public async Task<IActionResult> Post([FromBody]AssetModel model)
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
                    return Ok(_assetService.CreateAsset(model));
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
        public async Task<IActionResult> Put(Guid id, [FromBody]AssetModel model)
        {
            try
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentUser != null)
                {
                    model.ModifyUserId = Guid.Parse(currentUser.Id);
                    model.ModifyDate = DateTime.Now;
                    var result = _assetService.UpdateAsset(id, model);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return BadRequest("An error has occurred, please contact system administrator!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}/categories")]
        public IActionResult GetCategoriesForAsset(Guid id)
        {
            var result = _assetCategoryService.GetCategoriesForAsset(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("{id}/categories")]
        public async Task<IActionResult> LinkCategoryForAsset([FromBody]List<AssetCategoryModel> models, Guid id)
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
                var result = _assetCategoryService.AddAssetsForCategory(models, id);
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
