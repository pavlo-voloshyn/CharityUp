using DataAccess.Contracts;
using DataAccess.Persistence;
using Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class FoundationRepository : IFoundationRepository
{
    private readonly IMongoCollection<Foundation> _foundationCollection;

    public FoundationRepository(
        IOptions<FoundationDatabaseSettings> foundationDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            foundationDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            foundationDatabaseSettings.Value.DatabaseName);

        _foundationCollection = mongoDatabase.GetCollection<Foundation>(
            foundationDatabaseSettings.Value.FoundationCollectionName);
    }

    public async Task<List<Foundation>> GetAsync()
    {
        return await _foundationCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Foundation> GetAsync(string id)
    {
        return await _foundationCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Foundation foundation)
    {
        await _foundationCollection.InsertOneAsync(foundation);
    }

    public async Task UpdateAsync(string id, Foundation foundation)
    {
        await _foundationCollection.ReplaceOneAsync(x => x.Id == id, foundation);
    }

    public async Task RemoveAsync(string id)
    {
        await _foundationCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task AddFoundationInTransaction(IClientSessionHandle session, Foundation foundation)
    {
        await _foundationCollection.InsertOneAsync(session, foundation);
    }
}
