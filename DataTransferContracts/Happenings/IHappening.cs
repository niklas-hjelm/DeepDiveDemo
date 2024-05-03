namespace DataTransferContracts.Happenings;

public interface IHappening
{
    string Name { get; set; }
    string Description { get; set; }
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    string Location { get; set; }
    string ImageUrl { get; set; }
    ICollection<ISession> Sessions { get; set; }
}