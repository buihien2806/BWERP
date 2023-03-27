using BWERP.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
			var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = roleId,
				Name = "admin",
				NormalizedName = "admin",
				Description = "Administrator"
			});

			var hasher = new PasswordHasher<User>();
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = adminId,
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "orib@a2-cloud.com",
				NormalizedEmail = "ORIB@A2-CLOUD.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "abc@123"),
				SecurityStamp = Guid.NewGuid().ToString(),
				FirstName = "Hien",
				LastName = "Bui",
			});

			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
			{
				RoleId = roleId,
				UserId = adminId
			});
		}
	}
}
