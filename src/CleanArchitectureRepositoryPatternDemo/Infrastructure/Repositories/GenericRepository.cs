using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DemoContext _appContext;
        private readonly DbSet<T> _dbSet;

        protected GenericRepository(DemoContext appContext)
        {
            _appContext = appContext;
            _dbSet = _appContext.Set<T>();
        }

        public IDbConnection QueryConnection => _appContext.Database.GetDbConnection();

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellation)
        {
            await _dbSet.AddAsync(entity, cancellation);
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellation)
        {
            await _dbSet.AddRangeAsync(entities, cancellation);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<T?> GetIdAsync(int id, CancellationToken cancellation)
        {
            return await _dbSet.FindAsync(id, cancellation);
        }

        public virtual Task RemoveAsync(T entity, CancellationToken cancellation)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellation)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
