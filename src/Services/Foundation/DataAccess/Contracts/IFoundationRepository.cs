using FoundationService.Domain.Models;
using MongoDB.Driver;

namespace FoundationService.DataAccess.Contracts;

/// <summary>
/// Repositoty for manipulation of foundations in database
/// </summary>
public interface IFoundationRepository : IRepository<Foundation>
{
    /// <summary>
    /// Add foundation to database via transaction
    /// </summary>
    /// <param name="session">Session of transaction</param>
    /// <param name="foundation">A new foundation</param>
    /// <returns></returns>
    Task AddFoundationInTransaction(IClientSessionHandle session, Foundation foundation);
}
