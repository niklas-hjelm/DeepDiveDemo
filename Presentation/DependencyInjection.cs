using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FastEndpoints;

namespace API.Presentation;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddAuthorization(options =>
			{
				options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
				options.AddPolicy("Manager", policy => policy.RequireClaim(ClaimTypes.Role, ["Admin", "Manager"]));
				options.AddPolicy("Organizer", policy => policy.RequireClaim(ClaimTypes.Role, ["Admin", "Manager", "Organizer"]));
				options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, ["User", "Admin", "Manager", "Organizer"]));
			})
			.AddFastEndpoints();

		return services;
	}
}