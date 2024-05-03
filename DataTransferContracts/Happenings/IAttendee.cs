namespace DataTransferContracts.Happenings;

public interface IAttendee
{
    string Name { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
    string Address { get; set; }
    string City { get; set; }
    string State { get; set; }
    string ZipCode { get; set; }
    ICollection<ISession> Sessions { get; set; }
}