using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repsitories;
namespace Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static void AddPersistenceInfrastructurer(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(_configuration.GetConnectionString("DbConnectionString")));
            services.AddTransient<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddTransient<ITechnologyRepository, TechnologyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOperationClaimRepository, OperationClaimRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}