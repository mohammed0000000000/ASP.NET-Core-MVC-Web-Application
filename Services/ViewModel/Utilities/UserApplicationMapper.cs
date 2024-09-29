using AutoMapper;
using TechWebApplication.Models.Auth;

namespace TechWebApplication.Services.ViewModel.Utilities
{
    public class UserApplicationMapper:Profile
    {
        public UserApplicationMapper(){
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
        }
    }
}
