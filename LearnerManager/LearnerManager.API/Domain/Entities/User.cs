using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LearnerManager.API.Domain.Entities
{
    public class User : IdentityUser
    {
        public string School { get; set; }
        public string Region { get; set; }
    }
}
