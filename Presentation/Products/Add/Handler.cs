using API.Domain.Shop;
using API.Infrastructure.Products;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Products.Add;

public class Handler(IProductRepository repo) : Endpoint<IProduct, ServiceResponse<IProduct>>
{
	public override void Configure()
	{
		Post("/api/v1/products");
		Policies("Manager");
	}

	public override async Task HandleAsync(IProduct request, CancellationToken cancellationToken)
	{

		var product = await repo.AddAsync(request as Product ?? throw new InvalidOperationException());

		await SendAsync(new ServiceResponse<IProduct>()
		{
			Data = product,
			IsSuccess = product is not null,
			ErrorMessage = product is null ? "Product not added" : string.Empty
		}, cancellation: cancellationToken);
	}
}