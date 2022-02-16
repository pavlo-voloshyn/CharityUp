﻿using DataAccess.Contracts;
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

    public async Task<List<FoundationRequest>> GetAsync() =>
        await _foundationRequestCollection.Find(_ => true).ToListAsync();

    public async Task<FoundationRequest> GetAsync(string id) =>
        await _foundationRequestCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FoundationRequest newBook) =>
        await _foundationRequestCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, FoundationRequest updatedBook) =>
        await _foundationRequestCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _foundationRequestCollection.DeleteOneAsync(x => x.Id == id);
}
