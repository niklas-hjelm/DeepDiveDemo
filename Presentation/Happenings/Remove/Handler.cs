using API.Infrastructure.Happenings;
using DataTransferContracts;
using FastEndpoints;

namespace API.Presentation.Happenings.Remove;

public class Handler(IHappeningRepository repo) : Endpoint<Guid, ServiceResponse<bool>>
{
	public override void Configure()
	{
		Delete("/api/v1/happening/{id}");
		Policies("Organizer");
	}

	public override async Task HandleAsync(Guid id, CancellationToken cancellationToken)
	{
		//TODO: Add a check to see if the happening exists
		await repo.DeleteAsync(id);
		await SendAsync(new ServiceResponse<bool>()
		{
			IsSuccess = true
		}, cancellation:cancellationToken);
	}
}