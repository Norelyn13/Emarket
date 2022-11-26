using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<Entity> Create(Entity entity)
        {
            await _db.Set<Entity>().AddAsync(entity);
            await Save();
            return entity;
        }

        public virtual async Task<bool> Delete(Entity entity)
        {
            _db.Set<Entity>().Remove(entity);
            return await Save();
        }
        public virtual async Task<bool> Update(Entity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
        
        public virtual async Task<List<Entity>> GetAll()
        {
            return await _db.Set<Entity>().ToListAsync();
        }
        public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _db.Set<Entity>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }
        public virtual async Task<Entity> GetById(int id)
        {
            return await _db.Set<Entity>().FindAsync(id);
        }    
        public virtual async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}
