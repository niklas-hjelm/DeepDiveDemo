using CommonInterfaces.DataAccess;
using DataTransferContracts.Shop;

namespace API.Domain.Shop;

public class Category : ICategory, IEntity<string>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}