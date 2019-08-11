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

namespace LearnerManager.API.Services.ParentLearner
{
    public class ParentLearnerService : IParentLearnerService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly ILearnerService _learnerService;
        private readonly IParentService _parentService;


        public ParentLearnerService(IRepositoryWrapper repo, ILearnerService learnerService, IParentService parentService)
        {
            _repo = repo;
            _learnerService = learnerService;
            _parentService = parentService;
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

        public GetParentsForLearnerModel GetParentsForLearner(Guid learnerId)
        {
            try
            {
                var learner = _learnerService.GetById(learnerId);
                if (learner != null)
                {
                    // TODO Return parent data
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
                    learnerModel.Errors = new List<string>();

                    var learnerParents = _repo.ParentLearner.FindAll()
                        .Where(x => x.LearnerId == learnerModel.LearnerId)
                        .Select(x => x.ToModel()).ToList();
                    if (learnerParents.Count > 0)
                    {
                        foreach (var parentItem in learnerParents)
                        {
                            var parentModel = _parentService.GetById(parentItem.ParentId);
                            if (parentModel != null)
                            {
                                var exists =
                                    learnerModel.Parents.FirstOrDefault(x => x.ParentId == parentModel.ParentId);
                                if (exists == null)
                                {
                                    learnerModel.Parents.Add(parentModel);
                                }
                            }
                            else
                            {
                                learnerModel.Errors.Add("Could not find parent entity: Id= "+parentItem.LearnerId);
                            }
                        }
                    }
                    else
                    {
                        learnerModel.Errors.Add("Could not find parents for learner entity: id= "+learnerModel.LearnerId);
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

        public GetParentsForLearnerModel AddParentsForLearner(List<ParentLearnerModel> models, Guid id)
        {
            try
            {
                var learner = _learnerService.GetById(id);
                if (learner != null)
                {
                    // TODO Return parent data
                    var learnerModel = GetParentsForLearner(learner.LearnerId);

                    learnerModel.Errors = new List<string>();
                    foreach (var model in models)
                    {
                        var parentModel = _parentService.GetById(model.ParentId);
                        if (parentModel != null)
                        {
                            var exists = learnerModel.Parents.FirstOrDefault(x => x.ParentId == parentModel.ParentId);
                            if (exists == null)
                            {
                                var result = AddRelationShip(parentModel.ParentId, learnerModel.LearnerId);
                                if (result.Id != null)
                                {
                                    learnerModel.Parents.Add(parentModel);
                                }
                            }
                            else
                            {
                                learnerModel.Errors.Add("Parent entity: Id= "+parentModel.ParentId+" already exists");
                            }
                           
                        }
                        else
                        {
                            learnerModel.Errors.Add("Could not find parent with entity: Id= "+ model.ParentId);
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

        public GetLearnersForParentModel GetLearnersForParent(Guid parentId)
        {
            try
            {
                var parent = _parentService.GetById(parentId);
                if (parent != null)
                {
                    // TODO Return parent data
                    var parentModel = new GetLearnersForParentModel
                    {
                        ParentId = parent.ParentId,
                        FullName = parent.FullName,
                        Cellphone = parent.Cellphone,
                        Email = parent.Email,
                        Address = parent.Address,
                        Gender = parent.Gender,
                        IDNumber = parent.IDNumber,
                        Nationality = parent.Nationality,
                        StatusId = parent.StatusId
                    };
                    parentModel.Learners = new List<LearnerModel>();
                    parentModel.Errors = new List<string>();

                    var learnerParents = _repo.ParentLearner.FindAll()
                        .Where(x => x.ParentId == parentId)
                        .Select(x => x.ToModel())
                        .ToList();
                    if (learnerParents.Count > 0)
                    {
                        foreach (var learnerItem in learnerParents)
                        {
                            var learnerModel = _learnerService.GetById(learnerItem.LearnerId);
                            if (learnerModel!=null)
                            {
                                var exists =
                                    parentModel.Learners.FirstOrDefault(x => x.LearnerId == learnerModel.LearnerId);
                                if (exists == null)
                                {
                                    parentModel.Learners.Add(learnerModel);
                                }
                            }
                            else
                            {
                                parentModel.Errors.Add("Could not find Learner entity id: "+ learnerItem.LearnerId);
                            }
                        }
                    }
                    else
                    {
                        parentModel.Errors.Add("Could not find learners for parent id= " + parentModel.ParentId);
                    }

                    return parentModel;
                }

                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public GetLearnersForParentModel AddLearnersForParent(List<ParentLearnerModel> models, Guid id)
        {
            try
            {
                var parent = _parentService.GetById(id);
                if (parent != null)
                {
                    // TODO: refactor this in extensions
                    var parentModel = GetLearnersForParent(parent.ParentId);
                    parentModel.Errors = new List<string>();
                    foreach (var model in models)
                    {
                        var learnerModel = _learnerService.GetById(model.LearnerId);
                        if (learnerModel != null)
                        {
                            var exists = parentModel.Learners.FirstOrDefault(x => x.LearnerId == model.LearnerId);
                            if (exists == null)
                            {
                                var result = AddRelationShip(parentModel.ParentId, learnerModel.LearnerId);
                                if (result.Id != null)
                                {
                                    parentModel.Learners.Add(learnerModel);
                                }
                            }
                            else
                            {
                                parentModel.Errors.Add("Learner with entity: Id ="+model.LearnerId+" Already Exists! please contact system admin");
                            }
                          
                        }
                        else
                        {
                            parentModel.Errors.Add("Could not find learner with entity: Id="+model.LearnerId);
                        }
                    }

                    return parentModel;
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
