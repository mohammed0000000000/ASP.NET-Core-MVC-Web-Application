namespace TechWebApplication.Services.ViewModel
{
    public class UserToCategoryViewModel
    {
        public string UserId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();   
        public ICollection<CategoryViewModel> CategoriesSelecetd { get; set; } = new List<CategoryViewModel>(); 
    }
}
