using API.Domain.Happenings;
namespace API.Presentation.Happenings.UpdateSession;

public class Request
{
	public Guid HappeningId { get; set; }
	public Guid SessionId { get; set; }
	public Session Session { get; set; }
}