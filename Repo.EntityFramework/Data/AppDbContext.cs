using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Repo.EntityFramework.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category>Category { get; set; }
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<MediType> MediType { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }


        public AppDbContext():base(){ }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3ASORV1\\SQLEXPRESS01;Initial Catalog=TECWEBAPP;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
