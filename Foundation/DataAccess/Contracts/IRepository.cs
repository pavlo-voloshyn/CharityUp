namespace DataAccess.Contracts;

public interface IRepository<T>
{
    Task<List<T>> GetAsync();

    Task<T> GetAsync(string id);

    Task CreateAsync(T newEntity);

    Task UpdateAsync(string id, T updatedEntity);

    Task RemoveAsync(string id);
}
