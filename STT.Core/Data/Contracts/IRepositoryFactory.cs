namespace TRM_STT.Core.Data.Contracts
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;
    }
}