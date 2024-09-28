using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class ContentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Provide Title for Content")]
        [Length(5,80, ErrorMessage ="Provide Valid Title with at least 5 character")]
        public string Title { get; set; }
        
        [Display(Name = "HTML Content")]
        public string? HTMLContent { get; set; }

        [RegularExpression(@"^https?:\/\/([a-zA-Z0-9\-_]+\.)+[a-zA-Z]{2,}(:[0-9]{1,5})?(\/[a-zA-Z0-9\-._~:\/?#\[\]@!$&'()*+,;=%]*)?$", ErrorMessage = "Not a valid URL")]
        [Display(Name = "Video Link")]
        public string? VideoLink { get; set; }

        public int CategoryItemId { get; set; }
        //public CategoryItem CategoryItem { get; set; }
    }
}
