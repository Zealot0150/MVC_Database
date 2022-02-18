using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Database.ViewModels;

namespace MVC_Database.Models.Services
{
    public interface IServicePeople
    {
        public IEnumerable<Person> AllPeople { get; }


        public IEnumerable<Person> SearchPeople(string searchText);

        public bool DeleteUser(int id);

        public bool AddUser(CreatePersonViewModel peopleVM);
        public Person GetUSer(int id);

        public SelectList GetCityList();
        IEnumerable<string> GetLanguages(int id);
        DetailPeopleViewModel GetDPVM(int id);
        public SelectList GetLanguageList();
        bool AddLangToUser(LanguagePerson lp);
        bool DeleteLanguage(int id, string lang);
    }
}
