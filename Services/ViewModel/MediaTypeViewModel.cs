using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class MediaTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public string Title { get; set; }
        [Display(Name = "Thumbnail Image Path")]
        public string ThumbnailImagePath { get; set; }
        public List<CategoryItem> CategoryItems { get; set; }
    }
}
