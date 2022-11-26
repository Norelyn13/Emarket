using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        public Task<List<Entity>> GetAll();
        public Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);
        public Task<Entity> GetById(int id);
        public Task<bool> Update(Entity entity);
        public Task<bool> Delete(Entity entity);
        public Task<Entity> Create(Entity entity);
        public Task<bool> Save();
    }
}
