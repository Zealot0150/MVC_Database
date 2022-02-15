using System.Collections.Generic;
using MVC_Database.ViewModels;

namespace MVC_Database.Models.Services
{
    public interface IServicePeople
    {
        public IEnumerable<People> AllPeople { get; }


        public IEnumerable<People> SearchPeople(string searchText);

        public bool DeleteUser(int id);

        public bool AddUser(CreatePersonViewModel peopleVM);
        public People GetUSer(int id);
    }
}
