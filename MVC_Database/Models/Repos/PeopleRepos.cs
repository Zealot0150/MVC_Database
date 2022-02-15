using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Database.ViewModels;
using System.Linq.Expressions;
using MVC_Database.Models.Services;
using MVC_Database.Models;

namespace MVC_Basics.Models.Repos
{
    public class PeopleRepos:IServicePeople
    {
        private readonly AppDbContext appDbContext;
        public PeopleRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;

        }

        IEnumerable<People> IServicePeople.AllPeople
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
                People people = new People();
                people.City = peopleVM.City;
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
                List<People> list = appDbContext.People.ToList();
                People p = list.First(p => p.Id == id);
                appDbContext.People.Remove(p);
                appDbContext.SaveChanges();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        People IServicePeople.GetUSer(int id)
        {
            try
            {
                List<People> list = appDbContext.People.ToList();
                People p = list.First(p => p.Id == id);
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        IEnumerable<People> IServicePeople.SearchPeople(string searchText)
        {
            List<People> list = appDbContext.People.ToList();

            if (string.IsNullOrEmpty(searchText))
                return list;

            list = list.Where(s => s.City.Contains(searchText)
                            || s.Id.ToString().Contains(searchText)
                            || s.Tele.Contains(searchText)
                            || s.Name.ToString().Contains(searchText)
                            ).ToList();
            return list;
        }
    }
}
