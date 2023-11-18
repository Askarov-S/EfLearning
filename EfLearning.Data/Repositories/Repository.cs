using EfLearning.Data.DbContexts;
using EfLearning.Data.IRepositories;
using EfLearning.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EfLearning.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = appDbContext.Set<T>();
    }
    public async Task<T> CreateAsync(T entity)
    {
        var entry = await appDbContext.AddAsync(entity);
        await SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var deletedValue = await GetAsysn(i => i.Id == id);
        var entry = appDbContext.Remove(deletedValue);
        await SaveChangesAsync();
        return true;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null)
    {
        IQueryable<T> values = dbSet.Where(expression);
        return values;
    }
    public async Task<T> GetAsysn(Expression<Func<T, bool>>? expression)
    {
        var value =await GetAll().FirstOrDefaultAsync();
        return value;
    }

    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var updateValue = await GetAsysn(u=>u.Id == entity.Id);
        var entry = appDbContext.Update(updateValue);
        await SaveChangesAsync();
        return entry.Entity;
    }
}
