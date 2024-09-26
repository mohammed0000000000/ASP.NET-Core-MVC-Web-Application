using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repository;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Implementation
{
    public class CategoryItemServices:ICategoryItemServices
    {
        private readonly IRepository<CategoryItem, int> repo;
        private readonly IMapper mapper;
        //private readonly DbContext dbContext;
        public CategoryItemServices(IRepository<CategoryItem, int> repo, IMapper mapper) {
            this.repo = repo;
            this.mapper = mapper;
            //this.dbContext = dbContext;
        }

        public async Task<CategoryItemViewModel> Create(CategoryItemViewModel CategoryItemViewModel) {
            try {
                var categoryItemModel = mapper.Map<CategoryItem>(CategoryItemViewModel);
                var createdcategoryItemModel = await repo.Create(categoryItemModel);
                if (createdcategoryItemModel != null) {
                    return mapper.Map<CategoryItemViewModel>(createdcategoryItemModel);
                }
                return null;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
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

        public async Task<List<CategoryItemViewModel>> GetAll() {
            try {
                var res = await repo.GetAll();
                if (res is null)
                    return null;
                var categories = mapper.Map<List<CategoryItemViewModel>>(res);
                return categories;
            } catch (Exception ex) {
                throw;
            }
        }
        public async Task<List<CategoryItemViewModel>> GetAll(int id) {
            try {
                var res = await repo.GetAll();
                if (res is null)
                    return null;
                var res2 = await (from item in res
                            where item.CategoryId == id
                            select new CategoryItem{ Id = item.Id, Title = item.Title, Description = item.Description, DateTimeItemReleased = item.DateTimeItemReleased, MediaTypeId = item.MediaTypeId, CategoryId = item.CategoryId }).ToListAsync();
                var categories = mapper.Map<List<CategoryItemViewModel>>(res2);
                return categories;
            } catch (Exception ex) {
                throw;
            }
        }
        public async Task<CategoryItemViewModel> GetById(int id) {
            try {
                var categoryItemModel = await repo.GetbyId(id);
                if (categoryItemModel is null)
                    return null;
                var res = mapper.Map<CategoryItemViewModel>(categoryItemModel);
                return res;
            } catch (Exception ex) {
                throw;
            }
        }

        public async Task<bool> Update(int id, CategoryItemViewModel categoryItemViewModel) {
            try {
                var categoryItemModel = mapper.Map<CategoryItem>(categoryItemViewModel);
                var res = await repo.Update(categoryItemModel);
                return res;
            } catch (DbUpdateException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }
    }
}
