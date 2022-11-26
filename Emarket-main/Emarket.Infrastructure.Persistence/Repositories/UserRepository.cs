﻿using Emarket.Core.Application.Helpers;
using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Application.ViewModels.User;
using Emarket.Core.Domain.Entities;
using Emarket.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<User> Create(User entity)
        {
            entity.Password = EncryptedPass.ComputeSha256Hash(entity.Password);
            return  await base.Create(entity);
        }

        public async Task<User> Login(LoginVM vm)
        {
            string pass = EncryptedPass.ComputeSha256Hash(vm.Password);

            var item = await _db.Set<User>().
                FirstOrDefaultAsync(user => user.Username == vm.Username && user.Password == pass);

            return item;
        }
        public async Task<User> UserExist(SaveUserVM vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Username))
            {
                var item = await _db.Set<User>().
                    FirstOrDefaultAsync(user => user.Username.Trim().ToLower() == vm.Username.Trim().ToLower());

                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
