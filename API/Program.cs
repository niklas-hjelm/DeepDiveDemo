using API.Infrastructure;
using API.Infrastructure.Identity.Enteties;
using API.Infrastructure.Identity;
using API.Presentation;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddAuthentication(IdentityConstants.ApplicationScheme)
	.AddIdentityCookies();

builder.Services
	.AddAuthorizationBuilder();

builder.Services
	.AddIdentityCore<ApplicationUser>()
	.AddRoles<ApplicationRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddApiEndpoints();

builder.Services
	.AddCors(options => 
		options.AddPolicy(
		"wasm",
		policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "http://localhost:5161",
				builder.Configuration["FrontendUrl"] ?? "http://localhost:5241"])
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials()));

builder.Services.AddEndpointsApiExplorer();

builder.Services
	.AddPresentation(builder.Configuration)
	.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

app.UseCors("wasm");

app
	.UseAuthentication()
	.UseAuthorization()
	.UseFastEndpoints();

app.UseHttpsRedirection();

app.Run();
