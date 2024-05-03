using API.Infrastructure.Identity.Enteties;
using DataTransferContracts;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace API.Presentation.Identity.Roles.Remove;

public class Handler(UserManager<ApplicationUser> userManager) : Endpoint<Request, ServiceResponse<string>>
{
	public override void Configure()
	{
		Delete("/api/v1/roles");
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
		
		var result = await userManager.RemoveFromRoleAsync(user, request.Role);

		if (result.Succeeded)
		{
			await SendOkAsync(
				new ServiceResponse<string>
				{
					Data = request.Role,
					IsSuccess = true
				}, cancellationToken);
			return;
		}

		await SendAsync(
			new ServiceResponse<string>
			{
				ErrorMessage = string.Join("\n", result.Errors.Select(x => x.Description)),
				IsSuccess = false
			}, cancellation: cancellationToken);
	}
}