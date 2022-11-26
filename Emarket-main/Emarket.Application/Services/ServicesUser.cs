using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Ad;
using Emarket.Core.Application.ViewModels.User;
using Emarket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Services
{
    public class ServicesUser : IUserServices
    {
        private readonly IUserRepository _repo;

        public ServicesUser(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<SaveUserVM> Create(SaveUserVM vm)
        {
            User user = await _repo.Create(new User()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Username = vm.Username,
                Password = vm.Password,
                Email = vm.Email,
                Phone = vm.Phone

            });

            return (new SaveUserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone
            });
        }
        public async Task<UserVM> Login(LoginVM vm)
        {
            User user = await _repo.Login(vm);

            if (user == null)
            {
                return null;
            }


            return new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone

            };
        }
        public async Task<UserVM> UserExist(SaveUserVM vm)
        {
            var user = await _repo.UserExist(vm);

            if (user == null)
            {
                return null;
            }

            return new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone

            };
        }
        public async Task<bool> Delete(int id)
        {
            var item = await _repo.GetById(id);

            return await _repo.Delete(item);
        }

        public async Task<List<UserVM>> GetAll()
        {            
                var list = await _repo.GetAll();

                return list.Select(vm => new UserVM
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Username = vm.Username,
                    Password = vm.Password,
                    Email = vm.Email,
                    Phone = vm.Phone
                }).ToList();
            
        }

        public async Task<List<UserVM>> GetAllWithIncludeAsync()
        {
            var list = await _repo.GetAllWithIncludeAsync(new List<string> { "Ads"});

            return list.Select(vm => new UserVM
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Username = vm.Username,
                Password = vm.Password,
                Email = vm.Email,
                Phone = vm.Phone,
                AdOwnerQuantity = vm.Ads.Count
            }).ToList();
        }

        public async Task<SaveUserVM> GetById(int id)
        {
            var vm = await _repo.GetById(id);

            return new SaveUserVM
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Username = vm.Username,
                Password = vm.Password,
                Email = vm.Email,
                Phone = vm.Phone
            };
        }

        public async Task<bool> Update(SaveUserVM vm)
        {
            User item = await _repo.GetById(vm.Id);
            {
                item.Id = vm.Id;
                item.FirstName = vm.FirstName;
                item.LastName = vm.LastName;
                item.Username = vm.Username;
                item.Password = vm.Password;
                item.Email = vm.Email;
                item.Phone = vm.Phone;
            };

            return await _repo.Update(item);
        }
    }
}
