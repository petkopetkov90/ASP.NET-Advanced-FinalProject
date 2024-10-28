using System.Linq.Expressions;

namespace FleetRouteManager.Data.Repositories.Interfaces
{
    public interface IRepository<T, TKey>
        where T : class
    {
        IQueryable<T> GetAllAsIQueryable();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        Task<T?> GetByIdAsync(TKey id);
        T? GetById(TKey id);

        IQueryable<T> GetWhereAsIQueryable(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);

        bool Add(T entity);
        Task<bool> AddAsync(T entity);

        bool AddRange(IEnumerable<T> entities);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);

        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);

        bool UpdateRange(IEnumerable<T> entities);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);

        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);

        bool DeleteRange(IEnumerable<T> entities);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);

        bool Save();
        Task<bool> SaveAsync();
    }
}
