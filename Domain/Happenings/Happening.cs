using CommonInterfaces.DataAccess;
using DataTransferContracts.Happenings;

namespace API.Domain.Happenings;

public class Happening : IHappening, IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<ISession> Sessions { get; set; }
}