namespace DataTransferContracts.Shop;

public interface IProduct
{
    string Name { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    string? ImageUrl { get; set; }
    int Stock { get; set; }
    ICollection<ICategory> Categories { get; set; }
}