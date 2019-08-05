using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Domain.Repository.RepositoryWrapper;
using Microsoft.Extensions.DependencyInjection;

namespace LearnerManager.API.Helpers
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
