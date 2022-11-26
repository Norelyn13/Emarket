using Emarket.Core.Application.Helpers;
using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Ad;
using Emarket.Core.Application.ViewModels.User;
using Emarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Services
{
   public class ServicesAd : IAdsServices
    {
        private readonly IAdsRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVM user;

        public ServicesAd(IAdsRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            user = _httpContextAccessor.HttpContext.Session.Get<UserVM>("user");
        }
        public async Task<SaveAdsVM> Create(SaveAdsVM vm)
        {
            Ads ads = await _repo.Create(new Ads()
            {
                Name = capitalize(vm.Name),
                Description = vm.Description,             
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                UserId = user.Id
            });
            return (new SaveAdsVM
            {
                Id = ads.Id,
                Name = ads.Name,
                Description = ads.Description,
                Urls = new List<string>()
                {
                    ads.UrlPrimary,
                    ads.UrlSecondary,
                    ads.UrlThird,
                    ads.UrlFourth
                },
                Price = ads.Price,
                CategoryId = ads.CategoryId

            });
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _repo.GetById(id);
            return await _repo.Delete(item);
        }
        public async Task<bool> Update(SaveAdsVM vm)
        {
            int laps = 0;
            Ads item = await _repo.GetById(vm.Id);
            {
                item.Id = vm.Id;
                item.Name = capitalize(vm.Name);
                item.Description = vm.Description;
                item.Price = vm.Price;
                item.CategoryId = vm.CategoryId;

                foreach (string url in vm.Urls)
                {
                    laps += 1;

                    switch (laps)
                    {
                        case 1:
                            item.UrlPrimary = vm.Urls[0];
                            item.UrlSecondary = null;
                            item.UrlThird = null;
                            item.UrlFourth = null;
                            break;
                        case 2:
                            item.UrlSecondary = vm.Urls[1];
                            item.UrlThird = null;
                            item.UrlFourth = null;
                            break;
                        case 3:
                            item.UrlThird = vm.Urls[2];
                            item.UrlFourth = null;
                            break;
                        case 4:
                            item.UrlFourth = vm.Urls[3];
                            break;
                    }
                }
            }
            return await _repo.Update(item);         
        }

        public async Task<List<AdsVM>> GetAll()
        {
            var list = await _repo.GetAll();

            return list.Where(ads => ads.UserId == user.Id).Select(vm => new AdsVM
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

            return list.Where(ads => ads.UserId == user.Id).Select(vm => new AdsVM
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
                CategoryName = vm.Category.Name

            }).ToList();
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


        private string capitalize(string str)
        {

            if (str.Length == 0)
                return ("Empty String");
            else if (str.Length == 1)
                return char.ToUpper(str[0]) + "";
            else
                return (char.ToUpper(str[0]) +  str.Substring(1).ToLower());
        }

       
    }
}

