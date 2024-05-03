using API.Infrastructure.Orders;
using DataTransferContracts;
using FastEndpoints;

namespace API.Presentation.Orders.Remove;

public class Handler(IOrderRepository repo) : Endpoint<Guid, ServiceResponse<bool>>
{
	public override void Configure()
	{
		Delete("/api/v1/order/{id}");
		Policies("Customer");
	}

	public override async Task HandleAsync(Guid id, CancellationToken cancellationToken)
	{
		//TODO: Add a check to see if the order exists
		await repo.DeleteAsync(id);

		//TODO: Add a check to see if the order was deleted
		await SendAsync(new ServiceResponse<bool>()
		{
			IsSuccess = true
		}, cancellation:cancellationToken);
	}
}