using DataAccess.Contracts;
using DataAccess.Persistence;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MongoClient _client;
    private IClientSessionHandle _session;

    public UnitOfWork(IOptions<FoundationDatabaseSettings> foundationDatabaseSettings)
    {
        _client = new MongoClient(
           foundationDatabaseSettings.Value.ConnectionString);
    }

    public async Task<IClientSessionHandle> StartSessionAndTransactionAsync()
    {
        if (_session == null)
        {
            _session = await _client.StartSessionAsync();
            _session.StartTransaction();
        }
        return _session;
    }

    public async Task SaveChangesAsync()
    {
        await _session.CommitTransactionAsync();
    }
}
