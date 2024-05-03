using API.Domain.Shop;
using API.Infrastructure.Customers;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Customers.Add;

public class Handler(ICustomerRepository repo) : Endpoint<Customer, ServiceResponse<ICustomer>>
{
	public override void Configure()
	{
		Post("/api/v1/customers");
	}

	public override async Task HandleAsync(Customer request, CancellationToken cancellationToken)
	{
		var customer = new Customer
		{
			Id = Guid.NewGuid(),
			Name = request.Name,
			Email = request.Email,
			Address = request.Address,
			Phone = request.Phone
		};

		var result = await repo.AddAsync(customer);

		await SendAsync(new ServiceResponse<ICustomer>()
		{
			Data = result,
			IsSuccess = result is not null,
			ErrorMessage = result is not null ? string.Empty : "Failed to add customer"
		}, cancellation: cancellationToken);
	}
}