using Emarket.Core.Application.Helpers;
using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Ad;
using Emarket.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Services
{
    public class ServicesHome : IHomeServices
    {
        private readonly IAdsRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVM user;

        public ServicesHome(IAdsRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            user = _httpContextAccessor.HttpContext.Session.Get<UserVM>("user");
        }     

        public async Task<List<AdsVM>> GetAll()
        {
            var list = await _repo.GetAll();

            return list.Where(ads => ads.UserId != user.Id).Select(vm => new AdsVM
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Urls = new List<string>()
                {
                    vm.UrlPrimary,
                    vm.UrlSecondary,
                    vm.UrlThird,
                    vm.UrlFourth
                },
                Price = vm.Price,
                CategoryId = vm.CategoryId
            }).ToList();
        }
        public async Task<List<AdsVM>> GetAllWithIncludeAsync()
        {
            var list = await _repo.GetAllWithIncludeAsync(new List<string> { "Category" });

            return list.Where(ads => ads.UserId != user.Id).Select(vm => new AdsVM
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Urls = new List<string>()
                {
                    vm.UrlPrimary,
                    vm.UrlSecondary,
                    vm.UrlThird,
                    vm.UrlFourth
                },
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                CategoryName = vm.Category.Name,
                CreatedBy = vm.CreatedBy,
                Creadted = vm.Creadted,
                LastUpdate = vm.LastModified

            }).ToList();

        }
        public async Task<List<AdsVM>> GetAllWithIncludeAsyncByFilter(AdByFilter filter)
        {
            var list = await _repo.GetAllWithIncludeAsync(new List<string> { "Category" });

           
            var ListVM = list.Where(ads => ads.UserId != user.Id).Select(vm => new AdsVM
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Urls = new List<string>()
                {
                    vm.UrlPrimary,
                    vm.UrlSecondary,
                    vm.UrlThird,
                    vm.UrlFourth
                },
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                CategoryName = vm.Category.Name,
                CreatedBy = vm.CreatedBy,
                Creadted = vm.Creadted,
                LastUpdate = vm.LastModified

            }).ToList();

            List<AdsVM> FinalList = new();

            if (filter.categoryId.Count == 0 && filter.keyword == null)
            {
                return FinalList;
            }
        
            if (filter.categoryId != null && filter.categoryId.Count != 0)
            {
                foreach (int id in filter.categoryId)
                {
                    if (id != 0)
                    {
                        foreach (AdsVM item in ListVM)
                        {
                            if (item.CategoryId == id)
                            {
                                FinalList.Add(item);
                            }
                        }
                    }
                    else
                    {
                        FinalList = ListVM;
                        break;
                    }                  
                }
            }
            else
            {
                FinalList = ListVM;
            }

            if (!string.IsNullOrWhiteSpace(filter.keyword))
            {
                FinalList = FinalList.Where(ads => ads.Name.Contains(capitalize(filter.keyword))).ToList();
            }           

            return FinalList;
        }
        public async Task<SaveAdsVM> GetById(int id)
        {
            var vm = await _repo.GetById(id);

            return (new SaveAdsVM()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Urls = new List<string>()
                {
                    vm.UrlPrimary,
                    vm.UrlSecondary,
                    vm.UrlThird,
                    vm.UrlFourth
                },
                Price = vm.Price,
                CategoryId = vm.CategoryId
            });

        }

        public async Task<AdsVM> getByIdWithInclude(int id)
        {
            var list = await _repo.GetAllWithIncludeAsync(new List<string> { "Category","User" });

           var vm = list.Find(ads => ads.Id == id);

            return (new AdsVM()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Urls = new List<string>()
                {
                    vm.UrlPrimary,
                    vm.UrlSecondary,
                    vm.UrlThird,
                    vm.UrlFourth
                },
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                CategoryName = vm.Category.Name,
                CreatedBy = vm.CreatedBy,
                Creadted = vm.Creadted,
                LastUpdate = vm.LastModified,
                Phone = vm.User.Phone,
                Email = vm.User.Email
            });
        }
        public Task<bool> Update(SaveAdsVM vm)
        {
            throw new NotImplementedException();
        }

        public Task<SaveAdsVM> Create(SaveAdsVM vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        private string capitalize(string str)
        {

            if (str.Length == 0)
                return ("Empty String");
            else if (str.Length == 1)
                return char.ToUpper(str[0]) + "";
            else
                return (char.ToUpper(str[0]) + str.Substring(1).ToLower());
        }
    }
}



