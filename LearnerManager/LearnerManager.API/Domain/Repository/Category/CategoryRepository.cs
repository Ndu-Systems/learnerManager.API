using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Category
{
    public class CategoryRepository: RepositoryBase<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
