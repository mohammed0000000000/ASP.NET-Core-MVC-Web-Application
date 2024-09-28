using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repository;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Implementation
{
    public class MediaTypeServices : IMediaTypeServices
    {
        private readonly IRepository<MediType, int> repo;
        private readonly IMapper mapper;
        public MediaTypeServices(IRepository<MediType, int> repo, IMapper mapper) {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<MediaTypeViewModel> GetById(int id) {
            try {
                var model = await repo.GetbyId(id);
                var res = mapper.Map<MediaTypeViewModel>(model);    
                return res;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }
        public async Task<bool> Delete(int id) {
            try{
                var res = await repo.DeleteById(id);
                return res;
            }
            catch(DbUpdateException ex){
                throw;
            }
            catch(Exception ex){
                throw;
            }
        }

        public async Task<List<MediaTypeViewModel>> GetAll() {
            try {
                var model = await repo.GetAll();
                var res = mapper.Map<List<MediaTypeViewModel>>(model);
                return res;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }

        public async Task<bool> Update(MediaTypeViewModel mediaTypeViewModel) {
            try {
                var  model =mapper.Map<MediType>(mediaTypeViewModel);
                var res = await repo.Update(model);
                return res;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }
    }
}
