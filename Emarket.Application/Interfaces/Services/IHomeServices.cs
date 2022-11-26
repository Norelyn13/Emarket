using Emarket.Core.Application.ViewModels.Ad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Interfaces.Services
{
    public interface IHomeServices : IGenericServices<SaveAdsVM,AdsVM>
    {
        Task<AdsVM> getByIdWithInclude(int id);
        Task<List<AdsVM>> GetAllWithIncludeAsyncByFilter(AdByFilter vm);
    }
}
