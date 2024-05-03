using API.Infrastructure.Orders;
using DataTransferContracts;
using DataTransferContracts.Orders;
using FastEndpoints;

namespace API.Presentation.Orders.GetById;

public class Handler(IOrderRepository repo) : Endpoint<Guid, ServiceResponse<IOrder>>
{
	public override void Configure()
	{
		Get("/api/v1/order/{id}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Guid id, CancellationToken cancellationToken)
	{
		var order = await repo.GetByIdAsync(id);
		await SendAsync(new ServiceResponse<IOrder>()
		{
			Data = order,
			IsSuccess = order is not null,
			ErrorMessage = order is null ? "Failed to get order" : string.Empty
		}, cancellation:cancellationToken);
	}
}