using BWERP.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Configurations
{
    public class AppMenuConfiguration : IEntityTypeConfiguration<AppMenu>
    {
        public void Configure(EntityTypeBuilder<AppMenu> builder)
        {
            builder.ToTable("AppMenus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Icon).HasMaxLength(50);
            builder.Property(x => x.Url).HasMaxLength(50);

            builder.HasOne(x => x.ParentItem).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
        }
    }
}
