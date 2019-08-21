using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.AssetCategory;
using LearnerManager.API.Contracts.Category;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IAssetCategoryService _assetCategoryService;
      
        public CategoriesController(ICategoryService categoryService, 
            IAssetCategoryService assetCategoryService)
        {
            _categoryService = categoryService;
            _assetCategoryService = assetCategoryService;
         }
        // GET: api/categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.GetAll());
        }

        // GET api/categories/f55b6e33-bcc4-4a6c-b9ad-0dd6e1f3cd1e
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_categoryService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryModel model)
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
                    return Ok(_categoryService.CreateCategory(model));
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
        public async Task<IActionResult> Put(Guid id, [FromBody]CategoryModel model)
        {
            try
            {

                var userId = User.Identity.Name;
                if (userId != null)
                {
                    model.ModifyUserId = Guid.Parse(userId);
                    model.ModifyDate = DateTime.Now;
                    var result = _categoryService.UpdateCategory(id, model);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("An error occurred whiles updating, please contact system administrator!");
                    }
                }

                return BadRequest("An error has occurred, please contact system administrator!");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}/assets")]
        public IActionResult GetAssetsForCategory(Guid id)
        {
            var result = _assetCategoryService.GetAssetsForCategory(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("{id}/assets")]
        public async Task<IActionResult> LinkAssetsForCategory([FromBody]List<AssetCategoryModel> models,Guid id)
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
