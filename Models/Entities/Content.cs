namespace TechWebApplication.Models.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string  Title { get; set; }  
        public string? HTMLContent { get; set; }
        public string? VideoLink{ get; set; }

        public int CategoryItemId { get; set; } 
        public CategoryItem CategoryItem { get; set; }
    }
}
