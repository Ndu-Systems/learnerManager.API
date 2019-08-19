using LearnerManager.API.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearnerManager.API.Domain
{
    public class RepositoryContext: IdentityDbContext<User>
    {
        private IConfigurationRoot _config;

        public RepositoryContext(DbContextOptions<RepositoryContext> options, IConfigurationRoot config)
            : base(options)
        {
            _config = config;
        }


        public DbSet<Learner> Learners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SMS> Smses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentLearner> ParentLearners { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
        }

    }
}
