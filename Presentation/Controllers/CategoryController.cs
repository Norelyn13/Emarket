using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Categories;
using Emarket.WebApp.middlewares;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emarket.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _services;
        private readonly ValidateUserSesion _validateSesion;


        public CategoryController(ICategoryServices services, ValidateUserSesion validateSesion)
        {
            _services = services;
            _validateSesion = validateSesion;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(await _services.GetAllWithIncludeAsync());
        }
        public IActionResult SaveCategoryVM()
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(new SaveCategoryVM());
        }
        [HttpPost]
        public async Task<IActionResult> SaveCategoryVM(SaveCategoryVM vm)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _services.Create(vm);
            return RedirectToRoute( new { controller = "Category", action = "Index" });
        }
        public async Task<IActionResult> EditCategoryVM(int id)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            var vm = await _services.GetById(id);
            return View("SaveCategoryVM", vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategoryVM(SaveCategoryVM vm)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveCategoryVM", vm);
            }

            await _services.Update(vm);
            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }
        public async Task<IActionResult> DeleteCategoryVM(int id)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            var vm = await _services.GetById(id);
            return View(vm);
        }
        [HttpPost]
        public async Task <IActionResult> DeleteCategoryVMPost(int id)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            await _services.Delete(id);
            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }
    }
}
