using API.Infrastructure.Customers;
using DataTransferContracts;
using FastEndpoints;

namespace API.Presentation.Customers.Remove;

public class Handler(ICustomerRepository repo) : Endpoint<Guid, ServiceResponse<bool>>
{
	public override void Configure()
	{
		Delete("/api/v1/customers/{id}");
		Policies("Manager");
	}

	public override async Task HandleAsync(Guid request, CancellationToken cancellationToken)
	{
		await repo.DeleteAsync(request);
		//TODO: Check if the customer was deleted
		await SendAsync(new ServiceResponse<bool>()
		{
			IsSuccess = true
		}, cancellation: cancellationToken);
	}
}