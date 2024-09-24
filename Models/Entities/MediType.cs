namespace TechWebApplication.Models.Entities
{
    public class MediType
    {
        public int Id { get; set; } 
        public string  Title   { get; set; }    
        public string ThumbnailImagePath{ get; set; }   

        public List<CategoryItem> CategoryItems { get; set; }
    }
}
