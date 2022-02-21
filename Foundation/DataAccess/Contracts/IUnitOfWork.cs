using MongoDB.Driver;

namespace DataAccess.Contracts;

/// <summary>
/// Tool for creating transaction
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Commit changes in transaction
    /// </summary>
    Task SaveChangesAsync();

    /// <summary>
    /// Start session and transaction
    /// </summary>
    /// <returns>Handle of transaction session</returns>
    Task<IClientSessionHandle> StartSessionAndTransactionAsync();
}
