using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repositories.Shared
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId>
        where T : Entity<TId>, new()
        where TId : struct
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<bool> AnyAsync(TId id)
        {
            return _dbSet.AnyAsync(x => x.Id.Equals(id));
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public ValueTask<T?> GetByIdAsync(TId id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public Task<List<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToListAsync();
        }
    }
}
