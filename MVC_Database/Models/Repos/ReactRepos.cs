using Microsoft.AspNetCore.Components;
using MVC_Database.Models.Services;
using MVC_Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Models.Repos
{

    

    public class ReactRepos : IReactService
    {

        private readonly AppDbContext appDbContext;
        public ReactRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public List<DetailPeopleViewModel> GetPeople()
        {
            List<DetailPeopleViewModel> list = new List<DetailPeopleViewModel>();
            string country;

            List<Person> peopleList = appDbContext.People.ToList();
            List<LanguagePerson> lang = appDbContext.LangugePerson.ToList();
            try
            {
                foreach (Person person in peopleList)
                {
                    List<LanguagePerson> languages = new List<LanguagePerson>();
                    country = appDbContext.City.First(c => c.CityId == person.CityId).CountryId;

                    languages= 
                    (from lp in appDbContext.LangugePerson
                       
                     where lp.PersonId == person.Id
                     select lp).ToList<LanguagePerson>();

                    list.Add(new DetailPeopleViewModel(person, country, languages));
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        bool IReactService.AddPerson(string name, string city, string tele)
        {
            try
            {
                Person p = new Person();
                p.Name = name;
                p.CityId = city;
                p.Tele = tele;
                appDbContext.People.Add(p);
                appDbContext.SaveChanges();

            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        List<City> IReactService.GetCities()
        {
            List<City> list = new();
            list = appDbContext.City.ToList();
                   

            return list;
        }

        public bool DeleteUser(int id)
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



    }
}
