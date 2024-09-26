using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Length(minimumLength:5, maximumLength:150,ErrorMessage = "Name of Category must between 5 - 150 Charachter")]
        public string Title { get; set; }
        [Required]
        [Length(minimumLength: 5, maximumLength: 150, ErrorMessage = "Please Provide Description for Categor")]
        public string? Description { get; set; }
        [Required]
        public string ThumbnailImagePath { get; set; }
    }
}
