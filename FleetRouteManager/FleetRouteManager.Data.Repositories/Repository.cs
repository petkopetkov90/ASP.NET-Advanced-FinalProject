﻿using FleetRouteManager.Data.Data;
using FleetRouteManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FleetRouteManager.Data.Repositories
{
    public class Repository<T, TKey>(FleetRouteManagerDbContext context) : IRepository<T, TKey>
        where T : class
    {
        public virtual IQueryable<T> GetAllAsIQueryable()
        {
            return context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual async Task<T?> GetByIdAsync(TKey id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual T? GetById(TKey id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetWhereAsIQueryable(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public virtual bool Add(T entity)
        {
            context.Set<T>().Add(entity);
            return Save();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await SaveAsync();
        }

        public virtual bool AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            return Save();
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            return await SaveAsync();
        }

        public virtual bool Update(T entity)
        {
            context.Set<T>().Update(entity);
            return Save();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return await SaveAsync();
        }

        public virtual bool UpdateRange(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            return Save();
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            return await SaveAsync();
        }

        public virtual bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return Save();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await SaveAsync();
        }

        public virtual bool DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            return Save();
        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            return await SaveAsync();
        }

        public virtual bool Save()
        {
            return context.SaveChanges() > 0;
        }

        public virtual async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}