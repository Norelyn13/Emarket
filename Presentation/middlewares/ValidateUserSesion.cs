using Emarket.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Emarket.Core.Application.Helpers;

namespace Emarket.WebApp.middlewares
{
    public class ValidateUserSesion
    {
        private readonly IHttpContextAccessor _context;

        public ValidateUserSesion(IHttpContextAccessor context)
        {
            _context = context;
        }
        public bool HaveUser()
        {
            UserVM user = _context.HttpContext.Session.Get<UserVM>("user");

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
