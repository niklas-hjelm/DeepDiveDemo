using MongoDB.Driver;

namespace API.Infrastructure.MongoDbUtils;

public abstract class MongoService<TEntity>
{
    public IMongoCollection<TEntity> Collection { get; }
    protected MongoService(MongoConfig config, string collectionName)
    {
        var client = new MongoClient(config.ConnectionString);
        var database = client.GetDatabase(config.DatabaseName);
        Collection = database.GetCollection<TEntity>(collectionName);
    }

}