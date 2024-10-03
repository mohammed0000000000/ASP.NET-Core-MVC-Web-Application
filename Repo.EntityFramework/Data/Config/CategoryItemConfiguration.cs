using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItem>
    {
        public void Configure(EntityTypeBuilder<CategoryItem> builder) {
            builder.Property(x => x.Title).IsRequired().HasColumnType("VARCHAR").HasMaxLength(180);
            builder.Property( x=> x.DateTimeItemReleased).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryItems).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.MediaType).WithMany(x => x.CategoryItems).HasForeignKey(x => x.MediaTypeId);


            builder.ToTable("CategoryItem");

        }
    }
}
