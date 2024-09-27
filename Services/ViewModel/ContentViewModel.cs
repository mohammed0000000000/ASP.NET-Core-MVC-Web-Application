using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class ContentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? HTMLContent { get; set; }
        public string? VideoLink { get; set; }

        public int CategoryItemId { get; set; }
        //public CategoryItem CategoryItem { get; set; }
    }
}
