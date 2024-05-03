using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.GetById;

public class Handler(IHappeningRepository repo) : Endpoint<Guid, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Get("/api/v1/happening/{id}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Guid id, CancellationToken cancellationToken)
	{
		var happening = await repo.GetByIdAsync(id);
		await SendAsync(new ServiceResponse<IHappening>()
		{
			Data = happening,
			IsSuccess = happening is not null,
			ErrorMessage = happening is null ? "Failed to get happening" : string.Empty
		}, cancellation:cancellationToken);
	}
}