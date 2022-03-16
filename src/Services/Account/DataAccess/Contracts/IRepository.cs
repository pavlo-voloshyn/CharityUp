namespace AccountService.DataAccess.Contracts;

public interface IRepository<TEntity>
{
    void Add(TEntity entity);

    void Delete(TEntity entity);

    IQueryable<TEntity> GetWhere(Func<TEntity, bool> predicate);

    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync<T>(T id);

    void Update(TEntity entity);

    Task SaveChangesAsync();
}
