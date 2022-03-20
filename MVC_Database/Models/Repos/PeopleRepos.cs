using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Database.ViewModels;
using System.Linq.Expressions;
using MVC_Database.Models.Services;
using MVC_Database.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Database.Models.Repos
{
    public class PeopleRepos:IServicePeople
    {
        private readonly AppDbContext appDbContext;
        public PeopleRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        IEnumerable<Person> IServicePeople.AllPeople
        {
            get
            {
                return appDbContext.People;
            }
        }

        bool IServicePeople.AddUser(CreatePersonViewModel peopleVM)
        {
            try
            {
                Person people = new();
                people.CityId = peopleVM.CityId;
                people.Name = peopleVM.Name;
                people.Tele = peopleVM.Tele;
                appDbContext.People.Add(people);
                appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;                        
        }

        bool IServicePeople.DeleteUser(int id)
        {
            try
            {
                List<Person> list = appDbContext.People.ToList();
                Person p = list.First(p => p.Id == id);
                appDbContext.People.Remove(p);
                appDbContext.SaveChanges();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        SelectList IServicePeople.GetCityList()
        {
            return new SelectList(appDbContext.City, "CityId", "CityId");
        }

        DetailPeopleViewModel IServicePeople.GetDPVM(int id)
        {
            Person p;
            string country; 
            try
            {
                p = appDbContext.People.First(p => p.Id == id);
                country = appDbContext.City.First(c => c.CityId == p.CityId).CountryId;
            }
            catch (Exception)
            {
                return null;
            }
            return new(p, country, null);
        }

        IEnumerable<string> IServicePeople.GetLanguages(int personId)
        {
            return
                (from p in appDbContext.People
                  join lp in appDbContext.LangugePerson on
                     p.Id equals lp.PersonId
                  where p.Id == personId
                 select lp.LanguageId );
        }

        public SelectList GetLanguageList()
        {

            return new SelectList(appDbContext.Language, "Name", "Name");
        }


        Person IServicePeople.GetUSer(int id)
        {
            try
            {
                List<Person> list = appDbContext.People.ToList();
                Person p = list.First(p => p.Id == id);
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        IEnumerable<Person> IServicePeople.SearchPeople(string searchText)
        {
            List<Person> list = appDbContext.People.ToList();

            if (string.IsNullOrEmpty(searchText))
                return list;

            list = list.Where(s => (s.City.ToString()??"").Contains(searchText)
                            || s.Id.ToString().Contains(searchText)
                            || s.Tele.Contains(searchText)
                            || s.Name.ToString().Contains(searchText)
                            ).ToList();
            return list;
        }

        bool IServicePeople.AddLangToUser(LanguagePerson lp)
        {
            try
            {
                // should not exist dublicates
                appDbContext.LangugePerson.Add(lp);
                appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        
        bool IServicePeople.DeleteLanguage(int id, string lang)
        {
            try
            {
                LanguagePerson lp = new ();
                lp.LanguageId = lang;
                lp.PersonId = id;
                appDbContext.LangugePerson.Remove(lp);
                appDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
