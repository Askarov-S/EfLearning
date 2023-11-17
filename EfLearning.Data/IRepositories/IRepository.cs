using EfLearning.Domain.Commons;
using System.Linq.Expressions;

namespace EfLearning.Data.IRepositories;

public interface IRepository<T> where T : Auditable
{
    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(long id);
    public Task<T> GetAsysn(Expression<Func<T,bool>>? expression);
    public IQueryable<T> GetAll(Expression<Func<T,bool>>? expression = null);
    Task SaveChangesAsync();
}
