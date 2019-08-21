using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LearnerManager.API.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public bool LockoutEnabled { get; set; }
        public string School { get; set; }
        public string Region { get; set; }
    }
}
