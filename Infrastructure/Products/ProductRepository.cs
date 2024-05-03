using API.Domain.Shop;
using API.Infrastructure.MongoDbUtils;
using MongoDB.Driver;

namespace API.Infrastructure.Products;

public class ProductRepository(MongoConfig config) : MongoService<Product>(config, "Products"), IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>?> GetMultipleAsync(int start, int count)
    {
        return await Collection.Find(_ => true).Skip(start).Limit(count).ToListAsync();
    }

    public async Task<Product?> AddAsync(Product entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<Product?> UpdateAsync(Product entity)
    {
        await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await Collection.DeleteOneAsync(x => x.Id == id);
    }
}