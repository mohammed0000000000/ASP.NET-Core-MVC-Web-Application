using AutoMapper;
using TechWebApplication.Models.Entities;
namespace TechWebApplication.Services.ViewModel.Utilities
{
    public class MediaTypeMapper:Profile
    {
        public MediaTypeMapper() {
            CreateMap<MediType,MediaTypeViewModel>().ReverseMap();  
        }
    }
}
