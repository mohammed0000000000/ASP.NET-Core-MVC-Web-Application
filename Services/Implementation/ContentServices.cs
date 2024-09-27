using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repository;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Implementation
{
    public class ContentServices : IContentServices
    {
        private readonly IRepository<Content, int> repo;
        private readonly IMapper mapper;
        public ContentServices(IRepository<Content, int> repo, IMapper mapper) {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<ContentViewModel> Create(ContentViewModel contentViewModel) {
            try {
                var model = mapper.Map<Content>(contentViewModel);
                var  contentModel  = await repo.Create(model);
                if (contentModel is null)
                    return null;
                var res = mapper.Map<ContentViewModel>(contentModel);
                return res;
            }
            catch (DbUpdateException dbex) { throw; }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> Delete(int id) {
            try {
                var item = await repo.GetbyId(id);
                var res = await repo.Delete(item);
                return res;
            } catch (DbUpdateException dbex) { throw; }
            catch(Exception ex){ throw; }
        }

        public async Task<ContentViewModel> GetByItemId(int itemId) {
            try {
                var allContent = await repo.GetAll();
                var content = await allContent.Where(x => x.CategoryItemId == itemId).FirstOrDefaultAsync();
                if (content is null)
                    return null;
                    var res = mapper.Map<ContentViewModel>(content);
                return res;
            } catch (DbUpdateException dbex) { throw; } catch (Exception ex) { throw; }
        }

        public async Task<ContentViewModel> GetById(int id) {
            try {
                var item = await repo.GetbyId(id);
                if (item is null) return null;
                var res = mapper.Map<ContentViewModel>(item);
                return res;
            } catch (DbUpdateException dbex) { throw; } catch (Exception ex) { throw; }
        }

        public async Task<ContentViewModel> Update(ContentViewModel contentViewModel) {
            try {
                var model = mapper.Map<Content>(contentViewModel);
                var res = await repo.Update(model);
                if(res is true){
                    return mapper.Map<ContentViewModel>(model);
                }
                return null;
            } catch (DbUpdateException dbex) { throw; } catch (Exception ex) { throw; }
        }
    }
}
