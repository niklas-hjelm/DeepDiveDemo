using API.Domain.Shop;
using CommonInterfaces.DataAccess;

namespace API.Infrastructure.Customers;

public interface ICustomerRepository : IRepository<Customer, Guid>
{

}