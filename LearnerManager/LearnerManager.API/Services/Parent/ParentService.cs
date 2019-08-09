using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Parent
{
    public class ParentService: IParentService
    {
        private readonly IRepositoryWrapper _repo;

        public ParentService(IRepositoryWrapper repo)
        {

        }
        public string CreateParent(ParentModel model)
        {
            throw new NotImplementedException();
        }

        public List<ParentModel> GetAllPArents()
        {
            throw new NotImplementedException();
        }

        public ParentModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string UpdateParent(Guid id, ParentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
