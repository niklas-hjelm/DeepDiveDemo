using API.Domain.Shop;
using API.Infrastructure.Products;
using DataTransferContracts;
using DataTransferContracts.Shop;
using FastEndpoints;

namespace API.Presentation.Products.Update;

public class Handler(IProductRepository repo) : Endpoint<Request, ServiceResponse<bool>>
{
	public override void Configure()
	{
		Put("/api/v1/products/{ProductId}");
		Policies("Manager");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var product = await repo.GetByIdAsync(request.ProductId) ?? throw new InvalidOperationException();
		product.Categories = request.Product.Categories;
		product.Description = request.Product.Description;
		product.Name = request.Product.Name;
		product.Price = request.Product.Price;
		await repo.UpdateAsync(product ?? throw new InvalidOperationException());
		await SendAsync(new ServiceResponse<bool>()
		{
			IsSuccess = true
		}, cancellation: cancellationToken);
	}
}