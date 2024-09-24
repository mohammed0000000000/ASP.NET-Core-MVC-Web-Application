using TechWebApplication.Models.Auth;

namespace TechWebApplication.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } 
        public string ThumbnailImagePath{ get; set;}

        public List<CategoryItem> CategoryItems { get; set; } = new List<CategoryItem>();
        public List<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();  
    }
}
