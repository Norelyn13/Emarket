using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Emarket.Core.Application.Helpers;
using Emarket.WebApp.middlewares;

namespace Emarket.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _services;
        private readonly ValidateUserSesion _validateSesion;
        
        public UserController(IUserServices services, ValidateUserSesion validateSesion)
        {
            _services = services;
            _validateSesion = validateSesion;

        }

        public IActionResult Register()
        {
            if (_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(new SaveUserVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserVM vm)
        {
            if (_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                vm.validateUser = false;
                return View(vm);
            }

            UserVM user = await _services.UserExist(vm);

            if(user != null)
            {
                vm.validateUser = true;
                ModelState.AddModelError("userValidation", "Este usuario ya existe.");
                return View(vm);

            }
            else
            {
                await _services.Create(vm);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

        }
        public IActionResult Login()
        {
            if (_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(new LoginVM());
        }
       [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            UserVM user = await _services.Login(vm);

            if (user != null)
            {
                HttpContext.Session.Set<UserVM>("user", user);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                vm.validate = true;
                ModelState.AddModelError("userValidation", "El usuario o la contraseña es incorrecto.");
            }

            return View(vm);
        }
        public IActionResult Logout(LoginVM vm)
        {
                HttpContext.Session.Remove("user");
                return RedirectToRoute(new { controller = "User", action = "Login" });
        }
    }
}
