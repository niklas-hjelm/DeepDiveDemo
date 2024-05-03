using API.Infrastructure.Customers;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Customers.GetMultiple;

public class Handler(ICustomerRepository repo) : Endpoint<Request, ServiceResponse<IEnumerable<ICustomer>>>
{
	public override void Configure()
	{
		Get("/api/v1/customers");
		Policies("Manager");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var customers = await repo.GetMultipleAsync(request.Start, request.Count);
		await SendAsync(new ServiceResponse<IEnumerable<ICustomer>>()
		{
			Data = customers,
			IsSuccess = customers is not null,
			ErrorMessage = customers is null ? "No customers found" : string.Empty
		}, cancellation: cancellationToken);
	}
}