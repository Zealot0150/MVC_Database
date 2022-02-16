using MVC_Database.Models.Services;
using MVC_Database.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Models.Repos
{
    public class CountryRepos : ICountryService
    {
        private readonly AppDbContext appDbContext;

        public CountryRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }


        void ICountryService.CreateCountry(CountryViewModel cVM)
        {
            Country c = new();
            c.Name = cVM.Name;

            appDbContext.Country.Add(c);
            appDbContext.SaveChanges(); 
        }

        void ICountryService.Delete(string id)
        {
            List<Country> list = appDbContext.Country.ToList();
            Country c = list.First(c => c.Name == id);
            appDbContext.Country.Remove(c);
            appDbContext.SaveChanges();
        }

        IEnumerable<Country> ICountryService.GetAllCountries()
        {
            return appDbContext.Country;
        }
    }
}
