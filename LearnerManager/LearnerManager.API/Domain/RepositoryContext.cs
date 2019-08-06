using LearnerManager.API.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearnerManager.API.Domain
{
    public class RepositoryContext: IdentityDbContext<User> 
    {

        public RepositoryContext()
        {

        }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
           
        }

        public DbSet<Learner> Learners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SMS> Smses { get; set; }
    }
}
