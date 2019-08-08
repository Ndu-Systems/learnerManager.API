using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Helpers.Enums;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LearnerManager.API
{
    //public class Program
    //{
    //    public static async Task Main(string[] args)
    //    {
    //        // Build the application host
    //        var host = CreateWebHostBuilder(args);

    //        //Seed Database
    //        // TODO: Refactor this ASAP
    //        using (var scope = host.Services.CreateScope())
    //        {
    //            var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    //            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    //            // get the list of roles in the Enum
    //            var roles = (Role[]) Enum.GetValues(typeof(Role));
    //            foreach (var role in roles)
    //            {
    //                // Create an identity role object out of the enum value
    //                var identityRole = new IdentityRole
    //                {
    //                    Id = role.GetRoleName(),
    //                    Name = role.GetRoleName()
    //                };

    //                // Create Role if it doesn't exist already.
    //                if (!await roleManager.RoleExistsAsync(roleName: identityRole.Name))
    //                {
    //                    var result = await roleManager.CreateAsync(identityRole);
    //                    if(!result.Succeeded) throw new Exception("role create failure");
    //                }
    //            }
    //            // admin user
    //            var user = new User
    //            {
    //                Email = "admin@learnermaneger.co.za",
    //                UserName = "TestAdmin",
    //                School = "Ndu Systems School of Tech",
    //                Region = "Fourways",
    //                LockoutEnabled = false
    //            };
    //            // Add the user to the database if it doesn't already exist
    //            if (await userManager.FindByEmailAsync(user.Email) == null)
    //            {
    //                var result = await userManager.CreateAsync(user, password: "Ahm3dia@!");
    //                if(!result.Succeeded) throw new Exception("Creating user failed");

    //                // Assign all roles to the admin user
    //                result = await userManager.AddToRolesAsync(user, roles.Select(r => r.GetRoleName()));
    //                if (!result.Succeeded) throw new Exception("Adding user role failed");
    //            }
    //        }

    //        host.Run();
    //        CreateWebHostBuilder(args).Run();
    //    }

    //    public static IWebHost CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //            .UseStartup<Startup>()
    //            .Build();

    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
