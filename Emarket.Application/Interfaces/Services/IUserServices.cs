using Emarket.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Interfaces.Services
{   public interface IUserServices : IGenericServices<SaveUserVM, UserVM>
    {
        Task<UserVM> Login(LoginVM vm);
        Task<UserVM> UserExist(SaveUserVM vm);


    }
}

