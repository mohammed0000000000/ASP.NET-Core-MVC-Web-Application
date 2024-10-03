using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.ThumbnailImagePath).IsRequired(true).HasMaxLength(255).HasColumnType("VARCHAR");
            builder.HasMany(x => x.ApplicationUsers).
            WithMany(x => x.Categories).UsingEntity<UserCategory>();
            builder.ToTable("Category");
        }
    }
}
