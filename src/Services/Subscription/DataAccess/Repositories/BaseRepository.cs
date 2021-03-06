using Microsoft.EntityFrameworkCore;
using SubscriptionService.DataAccess.Contracts;
using SubscriptionService.DataAccess.Presistence;

namespace SubscriptionService.DataAccess.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly SubscriptionDbContext _context;

    public BaseRepository(SubscriptionDbContext context)
    {
        _context = context;
    }

    public virtual void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async virtual Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual IQueryable<TEntity> GetWhere(Func<TEntity, bool> predicate)
    {
        return _context.Set<TEntity>().Where(predicate).AsQueryable();
    }

    public virtual async Task<TEntity> GetByIdAsync<T>(T id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
