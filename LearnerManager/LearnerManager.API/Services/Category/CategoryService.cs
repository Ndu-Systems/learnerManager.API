using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Category
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepositoryWrapper _repo;
        public CategoryService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public string CreateCategory(CategoryModel model)
        {
            try
            {
                model.CategoryId = Guid.NewGuid();
                model.StatusId = 1;
                _repo.Category.Create(model.ToEntity());
                _repo.Save();
                return "Category Created successfully !";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<CategoryModel> GetAll()
        {
            try
            {
                return _repo.Category.FindAll().Select(x => x.ToModel()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CategoryModel GetById(Guid id)
        {
            return _repo.Category.FindAll().FirstOrDefault(x => x.CategoryId == id).ToModel();
        }

        public string UpdateCategory(Guid id,CategoryModel model)
        {
            try
            {
               
                var categoryModel = GetById(id);
                if (categoryModel != null)
                {
                    categoryModel.CategoryId = model.CategoryId;
                    categoryModel.Description = model.Description;
                    categoryModel.StatusId = model.StatusId;
                    _repo.Category.Update(categoryModel.ToEntity());
                    _repo.Save();
                    return "Category updated successfully !";
                }
                else
                {
                    return null;
                }
          
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
