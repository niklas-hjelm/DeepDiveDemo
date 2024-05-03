using API.Domain.Orders;
using CommonInterfaces.DataAccess;
using DataTransferContracts.Orders;

namespace API.Infrastructure.Orders;

public interface IOrderRepository : IRepository<Order, Guid>
{
	Task<IEnumerable<IOrder>?> GetMultipleForCustomerAsync(string customerEmail, int start, int count);
}