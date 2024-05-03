using API.Domain.Shop;

namespace API.Presentation.Customers.Update;

public class Request
{
	public Guid CustomerId { get; set; }
	public Customer Customer { get; set; }
}