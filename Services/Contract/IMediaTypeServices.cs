using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Contract
{
    public interface IMediaTypeServices
    {
        Task<List<MediaTypeViewModel>> GetAll();
        Task<bool> Update(MediaTypeViewModel mediaTypeViewModel);
        Task<MediaTypeViewModel> GetById(int id);  
    }
}
