using API.Infrastructure.Happenings;
using API.Presentation.Happenings.GetAll;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.GetMultiple;

public class Handler(IHappeningRepository repo) : Endpoint<Request, ServiceResponse<IEnumerable<IHappening>>>
{
	public override void Configure()
	{
		Get("/api/v1/happening");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
	{
		var happenings = await repo.GetMultiple(request.Start, request.Count);
		await SendAsync(new ServiceResponse<IEnumerable<IHappening>>()
		{
			Data = happenings,
			IsSuccess = happenings is not null,
			ErrorMessage = happenings is null ? "Failed to get happenings" : string.Empty
		}, cancellation:cancellationToken);
	}
}