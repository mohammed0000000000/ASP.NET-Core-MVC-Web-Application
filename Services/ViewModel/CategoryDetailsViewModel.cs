namespace TechWebApplication.Services.ViewModel
{
    public class CategoryDetailsViewModel
    {
        public IEnumerable<GroupedCategoryItemsByCategoryViewModels> GroupedCategoryItemsByCategoryViewModels{ get; set; } = new List<GroupedCategoryItemsByCategoryViewModels>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
