using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.ParentLearner
{
    public class ParentLearnerService : IParentLearnerService
    {
        private readonly IRepositoryWrapper _repo;

        public ParentLearnerService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public ParentLearnerModel AddRelationShip(Guid parentId, Guid learnerId)
        {
            try
            {
                var parentLearnerModel = new ParentLearnerModel
                {
                    Id = Guid.NewGuid(),
                    ParentId = parentId,
                    LearnerId = learnerId
                };
                _repo.ParentLearner.Create(parentLearnerModel.ToEntity());
                _repo.Save();

                return parentLearnerModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<ParentLearnerModel> GetParentsForLearner(Guid learnerId)
        {
            try
            {
                var parents = _repo.ParentLearner.FindAll()
                                                 .Where(x => x.LearnerId == learnerId)
                                                 .Select(x => x.ToModel()).ToList();

                return parents ?? null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<ParentLearnerModel> GetLearnersForParent(Guid parentId)
        {
            try
            {
                var learners = _repo.ParentLearner.FindAll()
                    .Where(x => x.ParentId == parentId)
                    .Select(x => x.ToModel())
                    .ToList();
                return learners ?? null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
