using API.Infrastructure.Products;
using DataTransferContracts;
using FastEndpoints;

namespace API.Presentation.Products.Remove;

public class Handler(IProductRepository repo) : Endpoint<Guid, ServiceResponse<bool>>
{
	public override void Configure()
	{
		Delete("/api/v1/products/{id}");
		Policies("Manager");
	}

	public override async Task HandleAsync(Guid request, CancellationToken cancellationToken)
	{
		await repo.DeleteAsync(request);
		await SendAsync(new ServiceResponse<bool>()
		{
			IsSuccess = true
		}, cancellation: cancellationToken);
	}
}