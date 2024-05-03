using API.Infrastructure.Customers;
using API.Infrastructure.Happenings;
using API.Infrastructure.Identity;
using API.Infrastructure.MongoDbUtils;
using API.Infrastructure.Orders;
using API.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace API.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Auth"));

		//Todo: Add MongoDb configuration to application settings
		var mongoConfig = new MongoConfig()
		{
			ConnectionString = configuration["MongoDb:ConnectionString"],
			DatabaseName = configuration["MongoDb:DatabaseName"]
		};
		services.AddSingleton(mongoConfig);

		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IHappeningRepository, HappeningRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}
}