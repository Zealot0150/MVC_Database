using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;

namespace MVC_Database.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CountryController : Controller
    {
        private readonly ICountryService service;
        public CountryController(ICountryService _service)
        {
            this.service = _service;
        }


        // GET: CountryController
        public ActionResult Index()
        {
            return View(service.GetAllCountries());
        }


        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryViewModel CVM)
        {
            if(!ModelState.IsValid)
                return View();
            try
            {
                if (service.CreateCountry(CVM))
                {

                }
                else
                {
                    ModelState.AddModelError("Name", "Landet finns redan");
                    return View();
                }
                    
            }
            catch (System.Exception)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {

            return View();
        }


        public ActionResult Delete(string id)
        {
            try
            {
                service.Delete(id);
            }
            catch (System.Exception)
            {
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
