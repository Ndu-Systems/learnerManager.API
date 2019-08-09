using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Parent
{
    public interface IParentService
    {
        string CreateParent(ParentModel model);
        List<ParentModel> GetAllPArents();
        ParentModel GetById(Guid id);
        string UpdateParent(Guid id, ParentModel model);
    }
}
