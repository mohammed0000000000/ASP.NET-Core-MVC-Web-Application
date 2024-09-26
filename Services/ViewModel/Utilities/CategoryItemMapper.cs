using AutoMapper;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel.Utilities
{
    public class CategoryItemMapper:Profile
    {
        public CategoryItemMapper(){
            CreateMap<CategoryItem, CategoryItemViewModel>().ReverseMap();
        }
    }
}
