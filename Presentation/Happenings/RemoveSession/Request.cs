namespace API.Presentation.Happenings.RemoveSession;

public class Request
{
	public Guid HappeningId { get; set; }
	public Guid SessionId { get; set; }
}