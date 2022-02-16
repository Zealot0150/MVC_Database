using MVC_Database.ViewModels;
using System.Collections.Generic;

namespace MVC_Database.Models.Services
{
    public interface ICountryService
    {
        public IEnumerable<Country> GetAllCountries();

        void CreateCountry(CountryViewModel cVM);
        void Delete(string id);
    }
}
