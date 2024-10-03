namespace TechWebApplication.Services.ViewModel
{
    public class UserCategoryListViewModel
    {
        public int CategoryId { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> UsersSelected { get; set; }  
    }
}
