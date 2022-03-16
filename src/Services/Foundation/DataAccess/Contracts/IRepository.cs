namespace FoundationService.DataAccess.Contracts;

/// <summary>
/// Repository interface for CRUD operations
/// </summary>
/// <typeparam name="T">Type of entity in database</typeparam>
public interface IRepository<T>
{
    Task<List<T>> GetAsync();

    Task<T> GetAsync(string id);

    Task CreateAsync(T newEntity);

    Task UpdateAsync(string id, T updatedEntity);

    Task RemoveAsync(string id);
}
