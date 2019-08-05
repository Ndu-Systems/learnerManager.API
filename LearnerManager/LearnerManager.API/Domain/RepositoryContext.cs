using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnerManager.API.Domain
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Learner> Learners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SMS> Smses { get; set; }
    }
}
