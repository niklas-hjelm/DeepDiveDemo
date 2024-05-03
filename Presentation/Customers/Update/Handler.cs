using API.Domain.Shop;
using API.Infrastructure.Customers;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Customers.Update;

public class Handler(ICustomerRepository repo) : Endpoint<Request, ServiceResponse<ICustomer>>
{
	public override void Configure()
	{
		Put("/api/v1/customers/{id}");
		Policies("Manager");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var customer = await repo.GetByIdAsync(request.CustomerId);
		if (customer is null)
		{
			await SendAsync(new ServiceResponse<ICustomer>()
			{
				IsSuccess = false,
				ErrorMessage = "Customer not found"
			}, cancellation: cancellationToken);
			return;
		}

		customer.Name = request.Customer.Name;
		customer.Email = request.Customer.Email;
		customer.Phone = request.Customer.Phone;
		customer.Address = request.Customer.Address;
		customer.City = request.Customer.City;
		customer.State = request.Customer.State;

		await repo.UpdateAsync(customer);

		await SendAsync(new ServiceResponse<ICustomer>()
		{
			Data = customer,
			IsSuccess = true
		}, cancellation: cancellationToken);
	}
}