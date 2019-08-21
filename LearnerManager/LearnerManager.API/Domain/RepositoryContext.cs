using System;
using LearnerManager.API.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearnerManager.API.Domain
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SMS> Smses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentLearner> ParentLearners { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
           
        }



        #region  Seeding Methods here
        public void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "admin@studentio.net",
                    UserName = "admin@studentio.net",
                    Password = "Ndusystems@2019!",
                    School = "Ndu Systems School of Tech",
                    Region = "Fourways",
                    CreateUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    CreateDate = DateTime.Now,
                    ModifyUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    ModifyDate = DateTime.Now,
                    LockoutEnabled = false,
                    PhoneNumber = "+27746958064",
                    StatusId = 1
                },
                new User
                {
                    Email = "teacher@studentio.net",
                    UserName = "teacher@studentio.net",
                    Password = "Ndusystems@2019!",
                    School = "Ndu Systems School of Tech",
                    Region = "Fourways",
                    CreateUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    CreateDate = DateTime.Now,
                    ModifyUserId = Guid.Parse("ca4b48e8-3c65-4209-a283-810838e819f1"),
                    ModifyDate = DateTime.Now,
                    LockoutEnabled = false,
                    PhoneNumber = "+27746958064",
                    StatusId = 1
                }
            );
        }

        #endregion

    }
}
