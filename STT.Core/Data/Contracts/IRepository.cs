using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TRM_STT.Core.Domain.Enums;

namespace TRM_STT.Core.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter,
            TrackingState trackingState = TrackingState.Disabled);
        
        Task<IEnumerable<TEntity>> GetAllAsync(
            TrackingState trackingState = TrackingState.Disabled);

        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            TrackingState trackingState = TrackingState.Enabled);

        TEntity Create(TEntity item);

        TEntity Update(TEntity item);

        Task DeleteAsync(int id);
    }
}