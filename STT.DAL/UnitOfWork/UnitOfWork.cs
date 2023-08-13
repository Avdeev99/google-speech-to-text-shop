using System.Threading.Tasks;
using TRM_STT.Core.Data.Contracts;

namespace TRM_STT.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrmDbContext _dbContext;
        
        private readonly IRepositoryFactory _repositoryFactory;
        
        public UnitOfWork(TrmDbContext dbContext, IRepositoryFactory repositoryFactory)
        {
            _dbContext = dbContext;
            _repositoryFactory = repositoryFactory;
        }
        
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _repositoryFactory.GetRepository<TEntity>();
        }
        
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}