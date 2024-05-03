using API.Infrastructure.Orders;
using DataTransferContracts;
using DataTransferContracts.Orders;
using FastEndpoints;

namespace API.Presentation.Orders.GetMultipleForCustomer;

public class Handler(IOrderRepository repo) : Endpoint<Request, ServiceResponse<IEnumerable<IOrder>>>
{
	public override void Configure()
	{
		Get("/api/v1/order/customer/{customerEmail}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var orders = 
			await repo.GetMultipleForCustomerAsync(request.CustomerEmail, request.Start, request.Count);
		await SendAsync(new ServiceResponse<IEnumerable<IOrder>>()
		{
			Data = orders,
			IsSuccess = orders is not null,
			ErrorMessage = orders is null ? "Failed to get orders" : string.Empty
		}, cancellation:cancellationToken);
	}
}