using Common.Models;
using System.Linq.Expressions;

namespace Common.Data;

public interface IRepository<T> where T : IEntity
{
    Task CreateAsync(T entity);
    Task<IEnumerable<string>> GetIdsAsync();
    Task<IEnumerable<string>> GetIdsAsync(Expression<Func<T, bool>> filter);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task<T> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Guid id, T entity);
}
