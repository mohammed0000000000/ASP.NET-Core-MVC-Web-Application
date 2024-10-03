using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder) {
            builder.HasKey(x => x.Id);
            builder.ToTable("UserCategory");
        }
    }
}
