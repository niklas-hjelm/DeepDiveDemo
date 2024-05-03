using API.Infrastructure.Products;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Products.GetMultiple;

public class Handler(IProductRepository repo) : Endpoint<Request, ServiceResponse<IEnumerable<IProduct>>>
{
	public override void Configure()
	{
		Get("/api/v1/products");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var products = await repo.GetMultipleAsync(request.Start, request.Count);
		await SendAsync(new ServiceResponse<IEnumerable<IProduct>>()
		{
			Data = products,
			IsSuccess = products is not null,
			ErrorMessage = products is null ? "No products found" : string.Empty
		}, cancellation: cancellationToken);
	}
}