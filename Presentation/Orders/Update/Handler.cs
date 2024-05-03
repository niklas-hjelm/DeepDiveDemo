using API.Infrastructure.Orders;
using DataTransferContracts;
using DataTransferContracts.Orders;
using FastEndpoints;

namespace API.Presentation.Orders.Update;

public class Handler(IOrderRepository repo) : Endpoint<Request, ServiceResponse<IOrder>>
{
	public override void Configure()
	{
		Put("/api/v1/order/{orderId}");
		Policies("Customer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		(request.Order?? throw new InvalidOperationException()).Id = request.OrderId;
		var updated = await repo.UpdateAsync(request.Order ?? throw new InvalidOperationException());
		await SendAsync(new ServiceResponse<IOrder>()
		{
			Data = updated,
			IsSuccess = updated is not null,
			ErrorMessage = updated is null ? "Failed to update order" : string.Empty
		}, cancellation:cancellationToken);
	}
}