using System;
using Microsoft.Extensions.DependencyInjection;
using TRM_STT.Core.Data.Contracts;

namespace TRM_STT.DAL.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        
        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }
    }
}