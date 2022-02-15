using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MVC_Database.ViewModels
{
    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Namn är Oblicterat")]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Telefon is obligerat")]
        [StringLength(20, MinimumLength = 6)]
        public string Tele { get; set; }

        public string City { get; set; }
    }
}
