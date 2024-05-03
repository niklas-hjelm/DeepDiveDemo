using API.Infrastructure.Identity.Enteties;
using DataTransferContracts;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace API.Presentation.Identity.Roles.Add;

public class Handler(UserManager<ApplicationUser> userManager) : Endpoint<Request, ServiceResponse<string[]>>
{
	public override void Configure()
	{
		Post("/api/v1/roles");
		Policies("Admin");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(request.UserId);

		if (user is null)
		{
			await SendNotFoundAsync(cancellationToken);
			return;
		}

		var roles = await userManager.GetRolesAsync(user);

		var result = await userManager.AddToRolesAsync(user, request.Roles.Except(roles));

		if (result.Succeeded)
		{
			await SendOkAsync(
				new ()
				{
					Data = request.Roles,
					IsSuccess = true
				}, cancellationToken);
			return;
		}

		await SendAsync(
			new()
			{
				ErrorMessage = string.Join("\n", result.Errors.Select(x => x.Description)),
				IsSuccess = false
			}, cancellation: cancellationToken);
	}
}