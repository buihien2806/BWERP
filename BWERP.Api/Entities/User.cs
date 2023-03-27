using Microsoft.AspNetCore.Identity;

namespace BWERP.Api.Entities
{
	public class User : IdentityUser<Guid>
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime LastLogin { get; set; }
		public bool isActive { get; set; }
		public List<Task>? Tasks { get; set; }

	}
}
