using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class LoggedInUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string School { get; set; }
        public string Region { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
