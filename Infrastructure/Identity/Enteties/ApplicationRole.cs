using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.Identity.Enteties;

public class ApplicationRole : IdentityRole
{
	public ApplicationRole() { }

	public ApplicationRole(string roleName) : base(roleName) { }
	public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}