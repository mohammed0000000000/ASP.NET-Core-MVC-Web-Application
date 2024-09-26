using System.ComponentModel.DataAnnotations;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel
{
    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        [Required]
        [Length(minimumLength:5, maximumLength:120,ErrorMessage = "You Must Provide Name for Item")]
        public string Title { get; set; }
        public DateTime? DateTimeItemReleased { get; set; }
        [Required]
        [Length(minimumLength: 5, maximumLength: 120, ErrorMessage = "You Must Provide Description for Item")]
        public string Description { get; set; }


        [Required]
        public int CategoryId { get; set; }
        //public Category Category { get; set; }

        [Required]
        public int MediaTypeId { get; set; }
        //public MediType MediaType { get; set; }

        //public Content Content { get; set; }
    }
}
