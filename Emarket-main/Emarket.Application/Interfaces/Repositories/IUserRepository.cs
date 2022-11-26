using Emarket.Core.Application.ViewModels.User;
using Emarket.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Emarket.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Login(LoginVM vm);
        Task<User> UserExist(SaveUserVM vm);


    }
}