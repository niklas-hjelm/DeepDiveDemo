using API.Domain.Shop;
using API.Infrastructure.MongoDbUtils;
using MongoDB.Driver;

namespace API.Infrastructure.Customers;

public class CustomerRepository(MongoConfig config) : MongoService<Customer>(config, "Customers"), ICustomerRepository
{
    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Customer>?> GetMultipleAsync(int start, int count)
    {
        return await Collection.Find(_ => true).Skip(start).Limit(count).ToListAsync();
    }

    public async Task<Customer?> AddAsync(Customer entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<Customer?> UpdateAsync(Customer entity)
    {
        await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await Collection.DeleteOneAsync(x => x.Id == id);
    }
}