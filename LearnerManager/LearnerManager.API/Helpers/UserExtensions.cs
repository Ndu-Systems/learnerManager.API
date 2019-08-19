using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers
{
    public static class UserExtensions
    {
        public static string GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity) principal.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.Sid);
            return claims.Value;
        }
    }
}
