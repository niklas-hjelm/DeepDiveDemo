namespace DataTransferContracts.Shop;

public interface ICategory
{
    string Name { get; set; }
    string Description { get; set; }
    string ImageUrl { get; set; }
}