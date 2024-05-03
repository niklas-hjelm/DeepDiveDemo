using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.AddSession;

public class Handler(IHappeningRepository repo) : Endpoint<Request, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Post("/api/v1/happening/session");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var happening = await repo.AddSessionAsync(request.HappeningId, request.Session);
		await SendAsync(new ServiceResponse<IHappening>()
		{
			Data = happening,
			IsSuccess = happening is not null,
			ErrorMessage = happening is null ? "Failed to add session" : string.Empty
		}, cancellation:cancellationToken);
	}
}