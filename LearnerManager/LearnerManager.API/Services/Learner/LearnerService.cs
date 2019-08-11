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
        private readonly IParentLearnerService _parentLearnerService;
        private readonly IParentService _parentService;
        public LearnerService(IRepositoryWrapper repo, IParentLearnerService parentLearnerService, IParentService parentService)
        {
            _repo = repo;
            _parentLearnerService = parentLearnerService;
            _parentService = parentService;
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

        public GetParentsForLearnerModel GetParentsForLearner(Guid learnerId)
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
                    learnerModel.Parents = new List<ParentModel>();

                    var learnerParents = _parentLearnerService.GetParentsForLearner(learner.LearnerId);
                    if (learnerParents.Count > 0)
                    {
                        foreach (var parent in learnerParents)
                        {
                            var parentModel = _parentService.GetById(parent.ParentId);
                            if (parentModel != null)
                            {
                                learnerModel.Parents.Add(parentModel);
                                learnerModel.Error = null;
                            }
                            else
                            {
                                learnerModel.Error += "Could not find Parent entity id: " + parent.ParentId + "\n";
                            }
                        }
                    }
                    else
                    {
                        learnerModel.Error += "Could not find parents for learner id= " + learnerModel.LearnerId + "\n";
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

        public GetParentsForLearnerModel AddParentsForLearner(List<ParentLearnerModel> models, Guid learnerId)
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
                    learnerModel.Parents = new List<ParentModel>();
                    foreach (var model in models)
                    {
                        // TODO Return parent data
                        var parentModel = _parentService.GetById(model.ParentId);
                        if (parentModel != null)
                        {
                            var parentLearner = new ParentLearnerModel
                            {
                                Id = Guid.NewGuid(),
                                LearnerId = learnerModel.LearnerId,
                                ParentId = parentModel.ParentId
                            };
                            _repo.ParentLearner.Create(parentLearner.ToEntity());
                            _repo.Save();
                            learnerModel.Parents.Add(parentModel);
                            learnerModel.Error = null;
                        }
                        else
                        {
                            learnerModel.Error += "Could not find parent with Entity: Id= " + model.ParentId + "\n";
                        }
                    }

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
