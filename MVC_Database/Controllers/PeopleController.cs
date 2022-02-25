using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.Models;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IServicePeople peopleService;

        public PeopleController(IServicePeople peopleService)
        {
            this.peopleService = peopleService;
        }

        public IActionResult Index(PeopleViewModel model)
        {
            if (model == null || model.PeopleList == null)
            {
                PeopleViewModel peopleVM = new();
                peopleVM.PeopleList = peopleService.AllPeople;
                return View(peopleVM);
            }
            else
                return View(model);
        }


        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            SelectList citys = peopleService.GetCityList();
            ViewBag.Citys = citys;

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (peopleService.AddUser(createViewModel))
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.Citys = peopleService.GetCityList();
            return View(createViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            peopleService.DeleteUser(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(PeopleViewModel peopleVM)
        {
            peopleVM.PeopleList = peopleService.SearchPeople(peopleVM.SearchCriteria);
            return View(nameof(Index), peopleVM);
        }

        public IActionResult Details(int Id)
        {
            int i = Id;
            if (i == 0)
            {
                // här verkar inte redirect få med sig Id, utan den blir noll så tar den via sessionen istället då
                try
                {
                    i = int.Parse(HttpContext.Session.GetString("PersonId"));
                }
                catch (System.Exception)
                {
                    // timed out
                    return RedirectToAction(nameof(Index));
                }
            }

            List<string> Languages = peopleService.GetLanguages(i).ToList();

            ViewBag.Languages = Languages;
            DetailPeopleViewModel dp = peopleService.GetDPVM(i);
            return View(dp);
        }
        [HttpGet]
        public IActionResult AddLanguage(int Id)
        {
            HttpContext.Session.SetString("PersonId", Id.ToString());
            LanguagePerson lp = new ();
            lp.PersonId = Id;

            // KRALL
            // Här körde jag en (jag vet jobbig lösning men hjärnan var tröttt)
            // IList<string> list = peopleService.GetLanguages(Id).ToList();
            // SelectList s2 = new SelectList(list, "Name", "Name");

            SelectList s = peopleService.GetLanguageList();
            ViewBag.Name = s;  // bara att byta s2 för att få smällen
            ViewBag.CurrentID = Id;
            return View(lp);
        }


        public IActionResult DeleteLanguage(int id, string lang)
        {
            if (peopleService.DeleteLanguage(id, lang))
            {

            }
            List<string> Languages = peopleService.GetLanguages(id).ToList();
            ViewBag.Languages = Languages;
            DetailPeopleViewModel dp = peopleService.GetDPVM(id);
            return View("Details", dp);

            // fattar inte varför man inte kan köra den nedan, värdet på id försvinner då KRALL
            //return RedirectToAction(nameof(Details), id);
        }


        [HttpPost]
        public IActionResult AddLanguage(MVC_Database.Models.LanguagePerson lp)
        {
            try
            {
                lp.PersonId = int.Parse(HttpContext.Session.GetString("PersonId"));
            }
            catch (System.Exception)
            {
                // timed out
                return RedirectToAction(nameof(Index));
            }

            

            if (peopleService.AddLangToUser(lp))
                return RedirectToAction(nameof(Details), lp.PersonId);
            else
            {
                ModelState.AddModelError("Name", "Kunde inte skapa språk");
                return RedirectToAction(nameof(AddLanguage), lp.PersonId);
            }
        }


    }
       
}
