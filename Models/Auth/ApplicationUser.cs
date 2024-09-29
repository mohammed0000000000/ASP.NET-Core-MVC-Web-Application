using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]

        public string LastName { get; set; }
        [StringLength(250)]

        public string Address1 { get; set; }
        [StringLength(250)]

        public string Address2 { get; set; }
        [StringLength(250)]
        public string PostCode { get; set; }

        public List<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
