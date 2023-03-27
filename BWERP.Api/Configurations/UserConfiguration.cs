using BWERP.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
		}
	}
}
