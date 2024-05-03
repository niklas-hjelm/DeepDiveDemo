using API.Domain.Orders;
using API.Infrastructure.MongoDbUtils;
using DataTransferContracts.Orders;
using MongoDB.Driver;

namespace API.Infrastructure.Orders;

public class OrderRepository(MongoConfig config) : MongoService<Order>(config, "Orders"), IOrderRepository
{
	public async Task<Order?> GetByIdAsync(Guid id)
	{
		return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Order>?> GetMultipleAsync(int start, int count)
	{
		return await Collection.Find(_ => true).Skip(start).Limit(count).ToListAsync();
	}

	public async Task<Order?> AddAsync(Order entity)
	{
		await Collection.InsertOneAsync(entity);
		return entity;
	}

	public async Task<Order?> UpdateAsync(Order entity)
	{
		await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		return entity;
	}

	public async Task DeleteAsync(Guid id)
	{
		await Collection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<IEnumerable<IOrder>?> GetMultipleForCustomerAsync(string customerEmail, int start, int count)
	{
		return await Collection.Find(x => x.Customer.Email == customerEmail).Skip(start).Limit(count).ToListAsync();
	}
}