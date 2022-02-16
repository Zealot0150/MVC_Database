using System.Collections.Generic;
using MVC_Database.Models;

namespace MVC_Database.ViewModels
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> PeopleList { get; set; }
        public string SearchCriteria { get; set; }
        public int SelectedUser { get; set; } 
    }
}
