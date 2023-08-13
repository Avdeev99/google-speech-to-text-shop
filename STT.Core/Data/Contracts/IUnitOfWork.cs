using System.Threading.Tasks;

namespace TRM_STT.Core.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;
        
        void SaveChanges();
        
        Task SaveChangesAsync();
    }
}