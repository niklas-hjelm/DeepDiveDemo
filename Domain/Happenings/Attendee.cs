using CommonInterfaces.DataAccess;
using DataTransferContracts.Happenings;

namespace API.Domain.Happenings;

public class Attendee : IAttendee, IEntity<Guid>
{
    public Guid Id { get; set; }
    public string? UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public ICollection<ISession> Sessions { get; set; }
}