using DataAccess.Contracts;
using DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly PaymentDbContext context;

    public BaseRepository(PaymentDbContext context)
    {
        this.context = context;
    }

    public virtual void Add(TEntity entity)
    {
       context.Set<TEntity>().Add(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async virtual Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }
    public virtual IQueryable<TEntity> GetWhere(Func<TEntity, bool> predicate)
    {
        return context.Set<TEntity>().Where(predicate).AsQueryable();
    }

    public virtual async Task<TEntity> GetByIdAsync<T>(T id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public virtual void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
