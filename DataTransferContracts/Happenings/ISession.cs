namespace DataTransferContracts.Happenings;

public interface ISession
{
    string Title { get; set; }
    string Description { get; set; }
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    string Organizer { get; set; }
    string ImageUrl { get; set; }
    ICollection<IAttendee> Attendees { get; set; }
}