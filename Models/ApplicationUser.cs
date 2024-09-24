using Microsoft.AspNetCore.Identity;

namespace TechWebApplication.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string  PostCode { get; set; }   
        
    }
}
