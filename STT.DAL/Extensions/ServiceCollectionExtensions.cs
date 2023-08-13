using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRM_STT.Core.Data.Contracts;
using TRM_STT.DAL.Factories;
using TRM_STT.DAL.Repositories;

namespace TRM_STT.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbDataAccess(
            this IServiceCollection services,
            string dbConnectionStringName)
        {
            services.AddDbContext<TrmDbContext>(options => options.UseSqlServer(dbConnectionStringName));

            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}