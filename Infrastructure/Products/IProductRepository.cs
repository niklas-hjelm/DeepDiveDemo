using API.Domain.Shop;
using CommonInterfaces.DataAccess;

namespace API.Infrastructure.Products;

public interface IProductRepository : IRepository<Product, Guid>
{

}