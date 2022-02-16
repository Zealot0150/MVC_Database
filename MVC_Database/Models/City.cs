using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Database.Models
{
    public class City
    {

        [Key]
        public string CityId { get; set; }
        
        public string CountryId { get; set; }
        
        public Country Country { get; set; }

        public List<Person> Peoples = new();
    }
}
