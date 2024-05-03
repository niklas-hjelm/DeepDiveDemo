using API.Domain.Happenings;
using CommonInterfaces.DataAccess;

namespace API.Infrastructure.Happenings;

public interface IHappeningRepository : IRepository<Happening, Guid>
{
	Task<IEnumerable<Happening>?> GetMultiple(int start, int count);
	Task<Happening?> AddSessionAsync(Guid happeningId, Session session);
	Task<Happening?> RemoveSessionAsync(Guid happeningId, Guid sessionId);
	Task<Happening?> AddAttendeeAsync(Guid happeningId, Guid sessionId, Attendee attendee);
	Task<Happening?> RemoveAttendeeAsync(Guid happeningId, Guid sessionId, Guid attendeeId);
	Task<Happening?> UpdateSessionAsync(Guid happeningId, Guid sessionId, Session session);
}