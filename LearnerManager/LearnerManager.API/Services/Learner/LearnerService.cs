using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Learner
{
    public class LearnerService: ILearnerService
    {
        private readonly IRepositoryWrapper _repo;
        public LearnerService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public List<LearnerModel> GetAllLearners()
        {
            try
            {
                return _repo.Learner.FindAll().Select(x => x.ToModel()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public LearnerModel GetById(Guid id)
        {
            try
            {
                return _repo.Learner.FindAll().FirstOrDefault(x => x.LearnerId == id).ToModel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

      

        public LearnerModel CreateLearner(LearnerModel model)
        {
            try
            {
                model.LearnerId = Guid.NewGuid();
            
                model.StatusId = 1;
                _repo.Learner.Create(model.ToEntity());
                _repo.Save();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public LearnerModel UpdateLearner(Guid id,LearnerModel model)
        {
            try
            {
                var learnerModel = GetById(id);
                if (learnerModel != null)
                {
                    // TODO: refactor this in extensions

                    learnerModel.FirstName = model.FirstName;
                    learnerModel.LastName = model.LastName;
                    learnerModel.IDNumber = model.IDNumber;
                    learnerModel.Gender = model.Gender;
                    learnerModel.Race = model.Race;
                    learnerModel.SchoolName = model.SchoolName;
                    learnerModel.Grade = model.Grade;
                    learnerModel.Section = model.Section;
                    learnerModel.ModifyUserId = model.ModifyUserId;
                    learnerModel.ModifyDate = model.ModifyDate;
                    learnerModel.StatusId = model.StatusId;
                    _repo.Learner.Update(learnerModel.ToEntity());
                    _repo.Save();
                    return learnerModel;
                }

                return null;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
