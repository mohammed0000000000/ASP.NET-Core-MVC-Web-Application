using Microsoft.AspNetCore.Identity;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }

        public List<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
