using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;

namespace MVC_Database.Controllers
{
    public class LanguageController : Controller
    {

        readonly ILanguageService service;

        public LanguageController(ILanguageService _service)
        {
            service = _service;
        }

        // GET: LanguageController
        public ActionResult Index()
        {
            return View(service.GetAllLanguages());
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(string id)

        {
            ViewBag.user = id;
            ViewBag.Names =  service.GetUserByLanguage(id);
            return View();
        }

        // GET: LanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageViewModel lVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (service.CreateLanguage(lVM))
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError("Language", "Landet existerar redan, byt namn");
                }
                catch
                {
                    
                }
            }
            return View();
        }

        // GET: LanguageController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string Id)
        {
            service.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
