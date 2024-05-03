using API.Infrastructure.Products;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Products.GetById;

public class Handler(IProductRepository repo) : Endpoint<Guid, ServiceResponse<IProduct>>
{
	public override void Configure()
	{
		Get("/api/v1/products/{id}");
	}

	public override async Task HandleAsync(Guid request, CancellationToken cancellationToken)
	{
		var product = await repo.GetByIdAsync(request);
		await SendAsync(new ServiceResponse<IProduct>()
		{
			Data = product,
			IsSuccess = product is not null,
			ErrorMessage = product is null ? "No product found" : string.Empty
		}, cancellation: cancellationToken);
	}
}