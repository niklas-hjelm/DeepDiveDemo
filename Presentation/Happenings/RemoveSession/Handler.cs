using API.Domain.Happenings;
using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.RemoveSession;

public class Handler(IHappeningRepository repo) : Endpoint<Request, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Delete("/api/v1/happenings/{happeningId}/{sessionId}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var happening = await repo.RemoveSessionAsync(request.HappeningId, request.SessionId);
		await SendAsync(new ServiceResponse<IHappening>()
		{
			IsSuccess = true,
			Data = happening
		}, cancellation:cancellationToken);
	}
}