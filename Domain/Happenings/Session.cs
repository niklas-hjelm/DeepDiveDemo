using CommonInterfaces.DataAccess;
using DataTransferContracts.Happenings;

namespace API.Domain.Happenings;

public class Session : ISession, IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Organizer { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<IAttendee> Attendees { get; set; }
}