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
    public class DBInitializer
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DBInitializer(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await CreateAdmin();

           if (!_repositoryContext.Messages.Any())
           {
               _repositoryContext.AddRange(_seedMessages);
               await _repositoryContext.SaveChangesAsync();
           }
        }

        private async Task  CreateAdmin()
        {
            var user = await _userManager.FindByEmailAsync("admin@studentio.net");
            var Admin = "Admin";
            if (user == null)
            {
                //Check if a role for admin exist or nah
                if (!(await _roleManager.RoleExistsAsync(Admin)))
                    await _roleManager.CreateAsync(new IdentityRole(Admin));

                user = new User
                {
                    Email = "admin@studentio.net",
                    UserName = "admin@studentio.net",
                    School = "Ndu Systems School of Tech",
                    Region = "Fourways",
                    CreateUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    CreateDate = DateTime.Now,
                    ModifyUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    ModifyDate = DateTime.Now,
                    LockoutEnabled = false,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "+27746958064",
                    StatusId = 1
                };

                var createUserResult = await _userManager.CreateAsync(user, "Ndusystems@2019!");
                var addRoleResult = await _userManager.AddToRoleAsync(user, Admin);
                var addClaimResult = await _userManager.AddClaimAsync(user, new Claim("SuperUser", "True"));

                if (!createUserResult.Succeeded ||
                    !addRoleResult.Succeeded ||
                    !addClaimResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user or role");
                }
            }

            if (!_repositoryContext.Messages.Any())
            {
                _repositoryContext.AddRange(_seedMessages);
                await _repositoryContext.SaveChangesAsync();
            }
        }

        List<Message> _seedMessages = new List<Message>
        {
            new Message
            {
                MessageId = Guid.NewGuid(),
                MessageType = "Test Message Type",
                MessageBody = "Test body text limit is 100"
            },
            new Message
            {
                MessageId = Guid.NewGuid(),
                MessageType = "Test Message Type 2",
                MessageBody = "Test body text limit is 100"
            },

        };
    }

}
 
