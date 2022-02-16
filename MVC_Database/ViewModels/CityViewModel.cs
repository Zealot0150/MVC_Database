using MVC_Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Database.ViewModels
{
    public class CityViewModel
    {
        [Required(ErrorMessage = "Namn är Obligerat")]
        [StringLength(100, MinimumLength = 2)]
        public string CityId { get; set; }

        public string Name { get; set; }

        //public Country Country { get; set; }

        //public List<Person> Peoples = new();
    }
}
