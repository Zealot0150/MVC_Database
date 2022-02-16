using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Database.Models
{
    public class Country
    {

        [Key]
        public string Name { get; set; }

        public List<City> Cities = new();

    }
}
