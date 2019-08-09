using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Parent
{
    public class ParentService: IParentService
    {
        private readonly IRepositoryWrapper _repo;

        public ParentService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public ParentModel CreateParent(ParentModel model)
        {
            try
            {
               model.ParentId = Guid.NewGuid();
               model.StatusId = 1;
                _repo.Parent.Create(model.ToEntity());
                _repo.Save();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<ParentModel> GetAllPArents()
        {
            try
            {
                return _repo.Parent.FindAll().Select(x => x.ToModel()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ParentModel GetById(Guid id)
        {
            try
            {
                return _repo.Parent.FindAll().FirstOrDefault(x => x.ParentId == id).ToModel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ParentModel UpdateParent(Guid id, ParentModel model)
        {
            try
            {
                var parentModel = GetById(id);
                if (parentModel != null)
                {
                    parentModel.ParentId = model.ParentId;
                    parentModel.FullName = model.FullName;
                    parentModel.Email = model.Email;
                    parentModel.Cellphone = model.Cellphone;
                    parentModel.Address = model.Address;
                    parentModel.Gender = model.Gender;
                    parentModel.StatusId = model.StatusId;
                    _repo.Parent.Update(parentModel.ToEntity());
                    _repo.Save();
                    return parentModel;
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
