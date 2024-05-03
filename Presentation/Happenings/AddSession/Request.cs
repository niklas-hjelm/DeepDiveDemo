using API.Domain.Happenings;

namespace API.Presentation.Happenings.AddSession;

public class Request
{
	public Guid HappeningId { get; set; }
	public Session Session { get; set; }
}