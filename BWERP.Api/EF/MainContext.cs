using BWERP.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BWERP.Api.Configurations;
using Task = BWERP.Api.Entities.Task;
using BWERP.Api.Extensions;

namespace BWERP.Api.EF
{
	public class MainContext : IdentityDbContext<User, Role, Guid>
	{
		public MainContext(DbContextOptions<MainContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Identity Database
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new TaskConfiguration());

			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

			//Data Seeding  
			modelBuilder.Seed();
		}

		public DbSet<Task> Tasks { get; set; }
	}
}
