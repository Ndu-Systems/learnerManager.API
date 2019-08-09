using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Category
{
   public interface ICategoryService
   {
       CategoryModel CreateCategory(CategoryModel model);
       List<CategoryModel> GetAll();
       CategoryModel GetById(Guid id);
       CategoryModel UpdateCategory(Guid id,CategoryModel model);
   }
}
