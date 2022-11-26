using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Ad;
using Emarket.WebApp.middlewares;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emarket.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ValidateUserSesion _validateUserSesion;
        private readonly IHomeServices _service;
        private readonly ICategoryServices _serviceCategory;

        public HomeController(ValidateUserSesion validateUserSesion, IHomeServices service, ICategoryServices serviceCategory)
        {
            _validateUserSesion = validateUserSesion;
            _service = service;
            _serviceCategory = serviceCategory;
        }
        public async  Task<IActionResult> Index()
        {
            if (!_validateUserSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            ViewBag.categories = await _serviceCategory.GetAll();
            var list = await _service.GetAllWithIncludeAsync();

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdByFilter vm)
        {
            if (!_validateUserSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }


            ViewBag.categories = await _serviceCategory.GetAll();
            var list = await _service.GetAllWithIncludeAsyncByFilter(vm);

            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (!_validateUserSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(await _service.getByIdWithInclude(id) );
        }
    }
}
