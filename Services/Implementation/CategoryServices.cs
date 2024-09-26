using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repository;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Implementation
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category, int> repo;
        private readonly IMapper mapper;

        public CategoryServices(IRepository<Category, int> repo, IMapper mapper) {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<CategoryViewModel> Create(CategoryViewModel categoryViewModel) {
            try{
                var categoryModel = mapper.Map<Category>(categoryViewModel);
                var createdCategoryModel = await repo.Create(categoryModel);
                if (createdCategoryModel != null) {
                    return mapper.Map<CategoryViewModel>(createdCategoryModel);
                }
                return null;
            }
            catch (DbUpdateException ex){
                throw;
            }
            catch (Exception ex){
                throw;
            }
        }

        public async Task<bool> Delete(int id) {
            try {
                var res = await repo.DeleteById(id);
                return res;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
            return false;
        }

        public async Task<List<CategoryViewModel>> GetAll() {
            try{
                var res = await repo.GetAll();
                if (res is null)
                    return null;
                var categories = mapper.Map<List<CategoryViewModel>>(res);
                return categories;
            }
            catch(Exception ex){
                throw;
            }
        }

        public async Task<CategoryViewModel> GetById(int id) {
            try{
                var categoryModel = await repo.GetbyId(id);
                if (categoryModel is null)
                    return null;
                var res = mapper.Map<CategoryViewModel>(categoryModel);
                return res;
            }
            catch(Exception ex){
                throw;
            }
        }

        public async Task<bool> Update(int id, CategoryViewModel categoryViewModel) {
            try {
                var categoryModel = mapper.Map<Category>(categoryViewModel);
                var res = await repo.Update(categoryModel);
                return res;
            } catch (DbUpdateException ex) {
                throw;
            }
            catch(Exception ex){
                throw;
            }
        }
    }
}
