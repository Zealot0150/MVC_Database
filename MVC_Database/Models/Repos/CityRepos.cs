using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Models.Repos
{
    public class CityRepos: ICityService
    {
        private readonly AppDbContext appDbContext;

        public CityRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        void ICityService.CreateCity(CityViewModel cVM)
        {
            City c = new();
            c.CityId = cVM.CityId;
            c.CountryId = cVM.Name;

            appDbContext.City.Add(c);
            appDbContext.SaveChanges();
            
        }

        IEnumerable<City> ICityService.GetAllCities()
        {
            return appDbContext.City;
        }

        SelectList ICityService.GetCountryList()
        {
            return new SelectList(appDbContext.Country, "Name", "Name");
        }
        public void Delete(string City)
        {
            List<City> list = appDbContext.City.ToList();
            City c = list.First(c => c.CityId == City);
            appDbContext.City.Remove(c);
            appDbContext.SaveChanges();
        }

    }
}
