using API.Domain.Happenings;
using API.Infrastructure.Happenings;
using DataTransferContracts;
using DataTransferContracts.Happenings;
using FastEndpoints;

namespace API.Presentation.Happenings.Add;

public class Handler(IHappeningRepository repo) : Endpoint<Happening, ServiceResponse<IHappening>>
{
	public override void Configure()
	{
		Post("/api/v1/happening");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Happening request,
		CancellationToken cancellationToken)
	{
		var added = await repo.AddAsync(request ?? throw new InvalidOperationException());
		await SendAsync(new ServiceResponse<IHappening>()
		{
			Data = added,
			IsSuccess = added is not null,
			ErrorMessage = added is null ? "Failed to add happening" : string.Empty
		},cancellation:cancellationToken);
	}
}