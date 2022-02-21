using Domain.Models;
using MongoDB.Driver;

namespace DataAccess.Contracts;

/// <summary>
/// Repository for manipulation of foundation request in database
/// </summary>
public interface IFoundationRequestRepository : IRepository<FoundationRequest>
{
    /// <summary>
    /// Delete foundation request via transaction
    /// </summary>
    /// <param name="session">Session of transaction</param>
    /// <param name="id">Id of foundation request to delete</param>
    /// <returns></returns>
    Task DeleteFoundationRequestInTransaction(IClientSessionHandle session, string id);
}
