using AutoMapper;
using TechWebApplication.Models.Entities;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.ViewModel.Utilities
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper() {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
