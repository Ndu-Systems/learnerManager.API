using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.AssetCategory;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IAssetCategoryService _assetCategoryService;
        public CategoriesController(ICategoryService categoryService, IAssetCategoryService assetCategoryService)
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
        public IActionResult Post([FromBody]CategoryModel model)
        {
            return Ok(_categoryService.CreateCategory(model));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]CategoryModel model)
        {
            var result = _categoryService.UpdateCategory(id, model);
            if (result!=null)
            { 
                return Ok(result);
            }
            else
            {
                return NotFound();
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
        public IActionResult LinkAssetsForCategory([FromBody]List<AssetCategoryModel> models,Guid id)
        {
            var result = _assetCategoryService.AddAssetsForCategory(models, id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
