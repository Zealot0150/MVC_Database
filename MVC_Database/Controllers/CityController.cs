using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;

namespace MVC_Database.Controllers
{
    public class CityController : Controller
    {
        readonly ICityService cityService;
        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }

        // GET: CityController
        public ActionResult Index()
        {
            return View(cityService.GetAllCities());
        }
        
        public ActionResult Create()
        {
            ViewBag.Country = cityService.GetCountryList();
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityViewModel CVM)
        {
            
            try
            {
                cityService.CreateCity(CVM);
                ViewBag.Country = cityService.GetCountryList();
            }
            catch (System.Exception)
            {
                ViewBag.Country = cityService.GetCountryList();
                return View();

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                cityService.Delete(id);
            }
            catch (System.Exception)
            {
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
