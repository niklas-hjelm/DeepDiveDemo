using API.Domain.Happenings;
using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.UpdateSession;

public class Handler(IHappeningRepository repo) : Endpoint<Request, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Put("/api/v1/happenings/{happeningId}/{sessionId}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var happening = await repo.UpdateSessionAsync(
			request.HappeningId,
			request.SessionId,
			request.Session ?? throw new InvalidOperationException()
			);

		await SendAsync(new ServiceResponse<IHappening>()
		{
			IsSuccess = happening is not null,
			Data = happening,
			ErrorMessage = happening is null ? "Failed to update session" : string.Empty
		}, cancellation:cancellationToken);
	}
}