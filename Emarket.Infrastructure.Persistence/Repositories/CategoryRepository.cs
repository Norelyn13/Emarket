using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Domain.Entities;
using Emarket.Infrastructure.Persistence.Context;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    { 
    
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}
