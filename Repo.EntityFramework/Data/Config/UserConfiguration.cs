using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Auth;

namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Address1).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Address2).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PostCode).IsRequired().HasMaxLength(50);

        }
    }
}
