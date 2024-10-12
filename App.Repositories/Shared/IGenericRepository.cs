using App.Models.Models;
using System.Linq.Expressions;

namespace App.Repositories.Shared
{
    public interface IGenericRepository<T, TId>
        where T : Entity<TId>, new()
        where TId : struct
    {
        Task<bool> AnyAsync(TId id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
        ValueTask<T?> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);
    }
}
