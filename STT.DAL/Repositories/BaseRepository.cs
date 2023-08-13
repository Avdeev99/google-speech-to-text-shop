using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRM_STT.Core.Data.Contracts;
using TRM_STT.Core.Domain.Enums;

namespace TRM_STT.DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _databaseSet;
        
        public BaseRepository(TrmDbContext context)
        {
            _databaseSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(TrackingState trackingState = TrackingState.Disabled)
        {
            var query = _databaseSet.AsQueryable();

            if (trackingState == TrackingState.Disabled)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter,
            TrackingState trackingState = TrackingState.Disabled)
        {
            var query = _databaseSet.AsQueryable();

            if (trackingState == TrackingState.Disabled)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            TrackingState trackingState = TrackingState.Disabled)
        {
            var query = _databaseSet.AsQueryable();

            if (trackingState == TrackingState.Disabled)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public TEntity Create(TEntity entity)
        {
            var createdEntity = _databaseSet.Add(entity).Entity;
            return createdEntity;
        }

        public TEntity Update(TEntity entity)
        {
            var updatedEntity = _databaseSet.Update(entity).Entity;
            return updatedEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _databaseSet.FindAsync(id);
            if (entity != null)
            {
                _databaseSet.Remove(entity);
            }
        }
    }
}