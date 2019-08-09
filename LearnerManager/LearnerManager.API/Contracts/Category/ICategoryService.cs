using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Category
{
   public interface ICategoryService
   {
       string CreateCategory(CategoryModel model);
       List<CategoryModel> GetAll();
       CategoryModel GetById(Guid id);
       string UpdateCategory(Guid id,CategoryModel model);
   }
}
