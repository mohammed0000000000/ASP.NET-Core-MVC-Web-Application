using AutoMapper;
using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.ViewModel.Utilities
{
    public class ContentMapper:Profile
    {
        public ContentMapper(){
            CreateMap<Content, ContentViewModel>().ReverseMap();
        }
    }
}
