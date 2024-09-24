namespace TechWebApplication.Models.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTimeItemReleased { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }  


        public int MediaTypeId{ get; set; }
        public MediType MediaType{ get; set; }

        public Content Content { get; set; }
    }
}
