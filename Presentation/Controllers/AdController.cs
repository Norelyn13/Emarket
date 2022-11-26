using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.ViewModels.Ad;
using Emarket.WebApp.middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Emarket.WebApp.Controllers
{
    public class AdController : Controller
    {
        private readonly ICategoryServices _servicesCategory;
        private readonly IAdsServices _services;
        private readonly ValidateUserSesion _validateSesion;

        public AdController(IAdsServices services,ICategoryServices servicesCategory, ValidateUserSesion validateSesion)
        {
            _services = services;
            _servicesCategory = servicesCategory;
            _validateSesion = validateSesion;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            var list = await _services.GetAllWithIncludeAsync();
            return View(list);
        }
        public async Task<IActionResult> SaveAdVM()
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(new SaveAdsVM()
            {
                Categories = await _servicesCategory.GetAll()
            }) ;
        }
        [HttpPost]
        public async Task<IActionResult> SaveAdVM(SaveAdsVM vm)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                vm.Categories = await _servicesCategory.GetAll();
                return View(vm);
            }

           SaveAdsVM ads = await _services.Create(vm);

            if (ads != null && ads.Id !=0)
            {
                ads.Urls.Clear();
                foreach (IFormFile item in vm.File)
                {
                    ads.Urls.Add(UploadFile(item, ads.Id));
                }
                await _services.Update(ads);
            }
            return RedirectToRoute(new { controller = "Ad", action = "Index" });
        }
        public async Task<IActionResult> EditAdVM(int id)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            var item = await _services.GetById(id);            
            item.Categories = await _servicesCategory.GetAll();

            return View("SaveAdVM",item);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdVM(SaveAdsVM vm)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            if (!ModelState.IsValid)
            {
                vm.Categories = await _servicesCategory.GetAll();
                return View("SaveAdVM",vm);
            }

            vm.Urls = new List<string>();

            SaveAdsVM ads = await _services.GetById(vm.Id);

           
            if(vm.File == null)
            {
                vm.Urls = ads.Urls;
                await _services.Update(vm);
                return RedirectToRoute(new { controller = "Ad", action = "Index" });
            }

            int counter = ads.Urls.Count - 1;

            for (int i = counter; i >= 0 ; i--)
            {                        
                if (string.IsNullOrEmpty(ads.Urls[i]))
                {
                    ads.Urls.Remove(ads.Urls[i]);
                }
            }
             
            if (vm.File.Count < ads.Urls.Count)
            {
                int space = ads.Urls.Count - vm.File.Count;

                
                for (int i = 0; i < space; i++)
                {
                    string basePath = $"/Img/Ads/{vm.Id}";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
                    string imagePath = ads.Urls.Last();

                    string[] oldImagePart = imagePath.Split("/");
                    string oldImagePath = oldImagePart[^1];
                    string completeImageOldPath = Path.Combine(path, oldImagePath);

                    if (System.IO.File.Exists(completeImageOldPath))
                    {
                        System.IO.File.Delete(completeImageOldPath);
                    }
                    ads.Urls.Remove(ads.Urls.Last());
                }
            }

            vm.Urls.Clear();

            int index = 0;
            counter = ads.Urls.Count;
            foreach (IFormFile item in vm.File)
            {               
                if (ads.Urls[index] == null)
                {
                    vm.Urls.Add(UploadFile(item, vm.Id));
                }
                else
                {
                    vm.Urls.Add(UploadFile(item, vm.Id, true, ads.Urls[index]));
                }
                index += 1;
                if (counter <= index)
                {
                    ads.Urls.Add(null);
                }
            }
            await _services.Update(vm);

            return RedirectToRoute(new { controller = "Ad", action = "Index" });
        }
        public async Task <IActionResult> DeleteAdVM(int id)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            var item = await _services.GetById(id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAdVMPost(SaveAdsVM vm)
        {
            if (!_validateSesion.HaveUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            string basePath = $"/Img/Ads/{vm.Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo item in directoryInfo.GetFiles())
                {
                    item.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }
            await _services.Delete(vm.Id);
            return RedirectToRoute(new { controller = "Ad", action = "Index" });
        }
        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Img/Ads/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }
    }
}
