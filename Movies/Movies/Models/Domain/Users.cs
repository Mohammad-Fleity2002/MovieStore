using Microsoft.AspNetCore.Identity;

namespace Movies.Models.Domain
{
	public class Users : IdentityUser
	{
		public string Name { get; set; }
	}
}
