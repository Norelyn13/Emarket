using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Categories;
using Emarket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Services
{
    public class ServicesCategory : ICategoryServices
    {
        private readonly ICategoryRepository _repo;

        public ServicesCategory(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<SaveCategoryVM> Create(SaveCategoryVM vm)
        {
            Category category = await _repo.Create(new Category()
            {
                Name = vm.Name,
                Description = vm.Description
            });

            return (new SaveCategoryVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _repo.GetById(id);
            return await _repo.Delete(item);
        }
        public async Task<bool> Update(SaveCategoryVM vm)
        {
            Category item = await _repo.GetById(vm.Id);
            {
                item.Id = vm.Id;
                item.Name = vm.Name;
                item.Description = vm.Description;
            }
            return await _repo.Update(item);
          
        }

        public async Task<List<CategoryVM>> GetAll()
        {
            var list = await _repo.GetAll();

            return list.Select(vm => new CategoryVM
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
            }).ToList();
        }       
        public async Task<List<CategoryVM>> GetAllWithIncludeAsync()
        {
            var list = await _repo.GetAllWithIncludeAsync(new List<string> { "Ads" });

            return list.Select(vm => new CategoryVM
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                AdQuantity = vm.Ads.Count,
                AdOwnerQuantity = vm.Ads.Select(ads => ads.UserId).Distinct().Count()

            }).ToList();
        }

        public async Task<SaveCategoryVM> GetById(int id)
        {
            var vm = await _repo.GetById(id);

            return (new SaveCategoryVM()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description
            });

        }

       
    }
}
