using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SimpleCrudApp.Domain;
using SimpleCrudApp.Service;
using SimpleCrudApp.ViewModels;

namespace SimpleCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitizenshipService _citizenshipService;
        public HomeController(ICitizenshipService citizenshipService)
        {
            _citizenshipService = citizenshipService;
            
        }
        [HttpGet]
        public  IActionResult CreateCitizenship()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCitizenship(CitizenShipViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _citizenshipService.CreateCitizenshipAsync(model);
                ModelState.Clear();
                ViewBag.isSuccess=true;
                return View();
            }
          
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCitizenDetails(Guid Id)
        {
            var citizenship= await _citizenshipService.GetByIdAsync(Id);
            return View(citizenship);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCitizenDetails(CitizenShipViewModel model)
        {
            if(ModelState.IsValid)
            {
                var citizenship = await _citizenshipService.UpdateCitizenshipAsync(model);
                if(citizenship==true)
                {
                    return RedirectToAction("GetAllCitizenship");
                }
 
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCitizenship()
        {
            var citizenships = await _citizenshipService.GetAllCitizenship();
            return View(citizenships);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
          await _citizenshipService.DeleteCitizenshipAsync(id);
         
                return RedirectToAction("GetAllCitizenship");
            
            
        }
    }
}
