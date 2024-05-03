using API.Domain.Happenings;
using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.Update;

public class Handler(IHappeningRepository repo) : Endpoint<Happening, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Put("/api/v1/happening");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Happening request, CancellationToken cancellationToken)
	{
		var happening = await repo.UpdateAsync(request ?? throw new InvalidOperationException());
		await SendAsync(new ServiceResponse<IHappening>()
		{
			IsSuccess = happening is not null,
			Data = happening,
			ErrorMessage = happening is null ? "Failed to update happening" : string.Empty
		}, cancellation:cancellationToken);
	}
}