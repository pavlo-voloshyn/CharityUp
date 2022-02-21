using DataAccess.Contracts;
using DataAccess.Persistence;
using Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class FoundationRequestRepository : IFoundationRequestRepository
{
    private readonly IMongoCollection<FoundationRequest> _foundationRequestCollection;

    public FoundationRequestRepository(
        IOptions<FoundationDatabaseSettings> foundationRequestDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            foundationRequestDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            foundationRequestDatabaseSettings.Value.DatabaseName);

        _foundationRequestCollection = mongoDatabase.GetCollection<FoundationRequest>(
            foundationRequestDatabaseSettings.Value.FoundationRequestCollectionName);
    }

    public async Task<List<FoundationRequest>> GetAsync()
    {
        return await _foundationRequestCollection.Find(_ => true).ToListAsync();
    }

    public async Task<FoundationRequest> GetAsync(string id)
    {
        return await _foundationRequestCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(FoundationRequest foundationRequest)
    {
        await _foundationRequestCollection.InsertOneAsync(foundationRequest);
    }

    public async Task UpdateAsync(string id, FoundationRequest foundationRequest)
    {
        await _foundationRequestCollection.ReplaceOneAsync(x => x.Id == id, foundationRequest);
    }

    public async Task RemoveAsync(string id)
    {
        await _foundationRequestCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task DeleteFoundationRequestInTransaction(IClientSessionHandle session, string id)
    {
        await _foundationRequestCollection.DeleteOneAsync(session, x => x.Id == id);
    }
}
