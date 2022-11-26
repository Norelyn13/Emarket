using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Core.Domain.Entities;
using Emarket.Infrastructure.Persistence.Context;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class AdsRepository : GenericRepository<Ads>, IAdsRepository
    {
        private readonly ApplicationDbContext _db;
        public AdsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
