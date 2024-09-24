using TechWebApplication.Models.Auth;

namespace TechWebApplication.Models.Entities
{
    public class UserCategory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
