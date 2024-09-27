using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.HTMLContent).IsRequired(false).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.VideoLink).IsRequired(false).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.HasOne(x => x.CategoryItem).WithOne(x => x.Content).HasForeignKey<Content>(x => x.CategoryItemId);
            builder.ToTable("Content");
        }
    }
}
