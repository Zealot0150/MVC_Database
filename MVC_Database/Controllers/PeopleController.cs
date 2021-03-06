using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;

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

        }
    }
