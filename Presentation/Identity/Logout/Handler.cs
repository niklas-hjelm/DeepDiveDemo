using API.Infrastructure.Identity.Enteties;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace API.Presentation.Identity.Logout;

public class Handler(SignInManager<ApplicationUser> signInManager) : Endpoint<object, EmptyResponse>
{
	public override void Configure()
	{
		Post("/api/v1/logout");
		Policies("User");
	}

	public override async Task HandleAsync(object? request, CancellationToken cancellationToken)
	{
		if (request is not null)
		{
			await signInManager.SignOutAsync();
				
			await SendOkAsync(cancellationToken);
		}

		await SendUnauthorizedAsync(cancellationToken);
	}
}