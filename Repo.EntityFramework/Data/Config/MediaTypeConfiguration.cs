using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechWebApplication.Models.Entities;
namespace TechWebApplication.Repo.EntityFramework.Data.Config
{
    public class MediaTypeConfiguration : IEntityTypeConfiguration<MediType>
    {
        public void Configure(EntityTypeBuilder<MediType> builder) {
            builder.Property(x => x.Title).IsRequired(true).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.ThumbnailImagePath).IsRequired(true).HasMaxLength(255).HasColumnType("VARCHAR");
            //builder.Property(x => x.)
            builder.ToTable("MediType");
        }
    }
}
