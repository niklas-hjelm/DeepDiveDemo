using CommonInterfaces.DataAccess;
using DataTransferContracts.Orders;
using DataTransferContracts.Shop;

namespace API.Domain.Shop;

public class Customer : ICustomer, IEntity<Guid>
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
}