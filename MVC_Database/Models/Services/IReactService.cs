using MVC_Database.ViewModels;
using System.Collections.Generic;

namespace MVC_Database.Models.Services
{
    public interface IReactService
    {
        public List<DetailPeopleViewModel> GetPeople();
        public List<City> GetCities();

        public bool AddPerson(string name, string city, string tele);

        public bool DeleteUser(int id);


    }
}
