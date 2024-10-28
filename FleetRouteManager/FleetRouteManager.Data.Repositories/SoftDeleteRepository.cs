using FleetRouteManager.Data.Data;
using FleetRouteManager.Data.Models.Interfaces;
using FleetRouteManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FleetRouteManager.Data.Repositories
{
    public class SoftDeleteRepository<T, TKey>(FleetRouteManagerDbContext context)
        : Repository<T, TKey>(context), ISoftDeleteRepository<T, TKey>
        where T : class, ISoftDeletable
    {
        private readonly FleetRouteManagerDbContext context = context;

        public override IQueryable<T> GetAllAsIQueryable()
        {
            return base.GetAllAsIQueryable()
                .Where(e => !e.IsDeleted);
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>()
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public override IEnumerable<T> GetAll()
        {
            return context.Set<T>()
                .Where(e => !e.IsDeleted)
                .ToList();
        }

        public override async Task<T?> GetByIdAsync(TKey id)
        {
            var entity = await base.GetByIdAsync(id);

            if (entity is null || entity.IsDeleted)
            {
                return null;
            }

            return entity;
        }

        public override T? GetById(TKey id)
        {
            var entity = base.GetById(id);

            if (entity is null || entity.IsDeleted)
            {
                return null;
            }

            return entity;
        }

        public override IQueryable<T> GetWhereAsIQueryable(Expression<Func<T, bool>> predicate)
        {
            return base.GetWhereAsIQueryable(predicate)
                .Where(e => !e.IsDeleted);
        }

        public override async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await base.GetWhereAsIQueryable(predicate)
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public override IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return base.GetWhereAsIQueryable(predicate)
                .Where(e => !e.IsDeleted)
                .ToList();
        }

        public override bool Delete(T entity)
        {
            entity.IsDeleted = true;
            return base.Update(entity);
        }

        public override async Task<bool> DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            return await base.UpdateAsync(entity);
        }

        public override bool DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            return base.UpdateRange(entities);
        }

        public override async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            return await base.UpdateRangeAsync(entities);
        }
    };
}
