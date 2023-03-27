using Microsoft.AspNetCore.Identity;

namespace BWERP.Api.Entities
{
	public class Role : IdentityRole<Guid>
	{
		public string? Description { get; set; }
	}
}
