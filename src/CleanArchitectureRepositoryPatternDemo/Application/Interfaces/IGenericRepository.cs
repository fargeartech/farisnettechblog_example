using System.Data;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> GetIdAsync(int id, CancellationToken cancellation);
        Task<T> AddAsync(T entity, CancellationToken cancellation);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellation);
        Task UpdateAsync(T entity, CancellationToken cancellation);
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellation);
        Task RemoveAsync(T entity, CancellationToken cancellation);
        IDbConnection QueryConnection { get; }
    }
}