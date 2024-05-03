using DataTransferContracts.Shop;

namespace DataTransferContracts.Orders;

public interface IOrderItem
{
    IProduct Product { get; set; }
    int Quantity { get; set; }
    decimal Price { get; set; }
}