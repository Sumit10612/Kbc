using Common.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Data.Mongo;

public class MongoRepository<T> : IRepository<T> where T : IEntity
{
    private readonly IMongoCollection<T> _dbCollection;
    private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase db, string CollectionName) =>
        _dbCollection = db.GetCollection<T>(CollectionName ?? typeof(T).Name);

    public Task CreateAsync(T entity) => _dbCollection.InsertOneAsync(entity);

    public Task<IEnumerable<string>> GetIdsAsync() => GetIdsAsync(d => true);

    public async Task<IEnumerable<string>> GetIdsAsync(Expression<Func<T, bool>> filter) =>
        (await _dbCollection.Find(filter).Project(new BsonDocument { { "_id", 1 } }).ToListAsync())
        .Select(x => x[0].AsString);

    public Task<IReadOnlyCollection<T>> GetAllAsync() => GetAllAsync(d => true);

    public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter) =>
         await _dbCollection.Find(filter).ToListAsync();

    public Task<T> GetAsync(Guid id) => GetAsync(d => d.Id == id);

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter) =>
        await _dbCollection.Find(filter).FirstOrDefaultAsync();

    public async Task RemoveAsync(Guid id) => await _dbCollection.DeleteOneAsync(_filterBuilder.Eq(e => e.Id, id));

    public async Task UpdateAsync(Guid id, T entity) =>
        await _dbCollection.ReplaceOneAsync(_filterBuilder.Eq(e => e.Id, id), entity);
}