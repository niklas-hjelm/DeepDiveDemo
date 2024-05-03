using CommonInterfaces.DataAccess;
using DataTransferContracts.Orders;
using DataTransferContracts.Shop;

namespace API.Domain.Orders;

public class OrderItem : IOrderItem, IEntity<Guid>
{
    public Guid Id { get; set; }
    public IProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}