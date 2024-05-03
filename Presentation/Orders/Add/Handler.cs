using API.Infrastructure.Orders;
using DataTransferContracts;
using DataTransferContracts.Orders;
using FastEndpoints;

namespace API.Presentation.Orders.Add;

public class Handler(IOrderRepository repo) : Endpoint<Domain.Orders.Order, ServiceResponse<IOrder>>
{
	public override void Configure()
	{
		Post("/api/v1/order");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Domain.Orders.Order request,
		CancellationToken cancellationToken)
	{
		var added = await repo.AddAsync(request ?? throw new InvalidOperationException());
		await SendAsync(new ServiceResponse<IOrder>()
		{
			Data = added,
			IsSuccess = added is not null,
			ErrorMessage = added is null ? "Failed to add order" : string.Empty
		}, cancellation:cancellationToken);
	}
}