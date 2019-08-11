using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
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

        public GetParentsForLearnerModel GetParentsForLearner(List<Guid> parentIds, Guid learnerId)
        {
           
            try
            {
                var learner = GetById(learnerId);
                if (learner != null)
                {
                    var learnerModel = new GetParentsForLearnerModel
                    {
                        LearnerId = learner.LearnerId,
                        FirstName = learner.FirstName,
                        LastName = learner.LastName,
                        Gender = learner.Gender,
                        Race = learner.Race,
                        DateOfBirth = learner.DateOfBirth,
                        IDNumber = learner.IDNumber,
                        SchoolName = learner.SchoolName,
                        Grade = learner.Grade,
                        Section = learner.Section,
                        StatusId = learner.StatusId
                    };

                    foreach (var id in parentIds)
                    {
                        // TODO Return parent data
                        learnerModel.ParentModels.Add(new ParentModel()
                        {
                            ParentId = Guid.NewGuid(),
                        });
                    }

                    return learnerModel;
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
                    learnerModel.StatusId = model.StatusId;
                    _repo.Learner.Update(learnerModel.ToEntity());
                    _repo.Save();
                    return learnerModel;
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
