using MongoDB.Driver;

namespace API.Infrastructure.MongoDbUtils;

public class MongoConfig
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}