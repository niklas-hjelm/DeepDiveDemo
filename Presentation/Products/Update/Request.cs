using API.Domain.Shop;

namespace API.Presentation.Products.Update;

public class Request
{
	public Guid ProductId { get; set; }
	public Product Product { get; set; }
}