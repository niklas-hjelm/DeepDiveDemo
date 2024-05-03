using API.Domain.Orders;
namespace API.Presentation.Orders.Update;

public class Request
{
	public Guid OrderId { get; set; }
	public Order Order { get; set; }
}