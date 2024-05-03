using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.Identity.Enteties;

public class ApplicationUser : IdentityUser
{
	public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
	public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
	public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
	public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}