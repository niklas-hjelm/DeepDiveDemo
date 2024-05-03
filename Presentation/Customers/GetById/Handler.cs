using API.Infrastructure.Customers;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Customers.GetById;

public class Handler(ICustomerRepository repo) : Endpoint<Guid, ServiceResponse<ICustomer>>
{
	public override void Configure()
	{
		Get("/api/v1/customers/{id}");
		Policies("User");
	}

	public override async Task HandleAsync(Guid request, CancellationToken cancellationToken)
	{
		var result = await repo.GetByIdAsync(request);

		await SendAsync(new ServiceResponse<ICustomer>()
		{
			Data = result,
			IsSuccess = result is not null,
			ErrorMessage = result is not null ? string.Empty : "Failed to get customer"
		}, cancellation: cancellationToken);
	}
}