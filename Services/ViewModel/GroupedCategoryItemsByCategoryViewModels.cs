namespace TechWebApplication.Services.ViewModel
{
    public class GroupedCategoryItemsByCategoryViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IGrouping<int,CategoryItemDetailsViewModel>Items { get; set; }
    }
}
