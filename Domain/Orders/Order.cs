using CommonInterfaces.DataAccess;
using DataTransferContracts.Orders;
using DataTransferContracts.Shop;

namespace API.Domain.Orders;

public class Order : IOrder, IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public ICollection<IOrderItem> Items { get; set; }
    public ICustomer Customer { get; set; }
}