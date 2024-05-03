using DataTransferContracts.Happenings;

namespace Client.Domain;

public class HappeningModel : IHappening
{
	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string Location { get; set; }
	public string ImageUrl { get; set; }
	public ICollection<ISession> Sessions { get; set; }
}