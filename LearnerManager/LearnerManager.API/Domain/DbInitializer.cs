using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LearnerManager.API.Domain
{
    public class DbInitializer
    {
        public DbInitializer(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        private RepositoryContext _repositoryContext;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                _repositoryContext = serviceScope.ServiceProvider.GetService<RepositoryContext>();

                if (!_repositoryContext.Users.Any())
                {
                    var user = await _userManager.FindByEmailAsync("admin@learnermaneger.co.za");
                    var Admin = "Admin";
                    if (user == null)
                    {
                        //Check if a role for admin exist or nah
                        if (!(await _roleManager.RoleExistsAsync(Admin)))
                            await _roleManager.CreateAsync(new IdentityRole(Admin));

                        user = new User
                        {
                            Email = "admin@learnermaneger.co.za",
                            UserName = "TestAdmin",
                            School = "Ndu Systems School of Tech",
                            Region = "Fourways"
                        };

                        var createUserResult = await _userManager.CreateAsync(user, "Password01!");
                        var addRoleResult = await _userManager.AddToRoleAsync(user, Admin);
                        var addClaimResult = await _userManager.AddClaimAsync(user, new Claim("SuperUser", "True"));

                        if (!createUserResult.Succeeded ||
                            !addRoleResult.Succeeded ||
                            !addClaimResult.Succeeded)
                        {
                            throw new InvalidOperationException("Failed to build user or role");
                        }
                    }
                }

                _repositoryContext.SaveChanges();
            }
        }

    }
}
