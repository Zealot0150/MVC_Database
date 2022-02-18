using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.ViewModels;
using System.Collections.Generic;

namespace MVC_Database.Models.Services
{
    public interface ICityService
    {
        public IEnumerable<City> GetAllCities();

        public SelectList GetCountryList();
        void CreateCity(CityViewModel cVM);

        public void Delete(string city);
        
    }
}
