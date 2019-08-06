using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers.Enums
{
    public enum Role
    {
        Admin,
        Teacher
    }
    public static class RoleEnumExtensions
    {
        public static string GetRoleName(this Role role) // convenience method
        {
            return role.ToString();
        }
    }
}
