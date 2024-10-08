using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Auth;
using TechWebApplication.Repo.EntityFramework.Data;
using TechWebApplication.Repository;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.Implementation;
using TechWebApplication.Services.ViewModel.Utilities;

namespace TechWebApplication
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("constr"));
            });
            builder.Services.AddScoped<DbContext, AppDbContext>();
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            builder.Services.AddAutoMapper(typeof(CategoryMapper).Assembly);
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICategoryItemServices, CategoryItemServices>();
            builder.Services.AddScoped<IContentServices, ContentServices>();
            builder.Services.AddScoped<IMediaTypeServices, MediaTypeServices>();
            builder.Services.AddScoped<IUserCategoryServices, UserCatgoryServices>();

            // Register UserManager and Role Manager
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option => {
            })
            .AddEntityFrameworkStores<AppDbContext>();

            //builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if(app.Environment.IsDevelopment()){
            //    app.UseDirectoryBrowser();
            //    //app.UseBrowserLink(); // Enable Browser Link
            //}
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
