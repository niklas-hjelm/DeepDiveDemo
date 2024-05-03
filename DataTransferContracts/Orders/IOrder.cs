using DataTransferContracts.Shop;

namespace DataTransferContracts.Orders;

public interface IOrder
{
    DateTime OrderDate { get; set; }
    decimal Total { get; set; }
    ICollection<IOrderItem> Items { get; set; }
    ICustomer Customer { get; set; }
}