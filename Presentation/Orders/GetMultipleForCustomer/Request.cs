namespace API.Presentation.Orders.GetMultipleForCustomer;

public class Request
{
	public string CustomerEmail { get; set; } = string.Empty;
	public int Start { get; set; }
	public int Count { get; set; }
}