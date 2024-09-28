using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Provide Title for Category")]
        [Length(minimumLength:5, maximumLength:80,ErrorMessage = "Name of Category must between 5 - 80 Charachter")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Provide Description for Category")]
        [Length(minimumLength: 10, maximumLength: 150, ErrorMessage = "Please Provide Description for Category")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Pleae Provide Thumbnail Image Path for Category")]
        [RegularExpression(@"^([a-zA-Z0-9\s_\\.\-:\/])+\.(jpg|jpeg|png|gif|bmp|tiff)$", ErrorMessage = "Not a valid image path")]
        [Display(Name = "Thumbnail Image Path")]
        public string ThumbnailImagePath { get; set; }
    }
}
