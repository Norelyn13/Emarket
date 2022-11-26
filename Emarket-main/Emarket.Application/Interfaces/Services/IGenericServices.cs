using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Interfaces.Services
{
    public interface IGenericServices<SaveVM,VM> 
        where SaveVM : class 
        where VM :class
    {
        public Task<List<VM>> GetAll();
        public Task<List<VM>> GetAllWithIncludeAsync();
        public Task<SaveVM> GetById(int id);
        public Task<bool> Update(SaveVM vm);
        public Task<bool> Delete(int id);
        public Task<SaveVM> Create(SaveVM vm);
    }
}
