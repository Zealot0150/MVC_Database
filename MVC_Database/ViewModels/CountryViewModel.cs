using System.ComponentModel.DataAnnotations;

namespace MVC_Database.ViewModels
{
    public class CountryViewModel
    {
        [Required(ErrorMessage = "Sluta nu Simon/Jonathan/Tobias Namn är Obligerat")]
        [StringLength(100, MinimumLength = 2)]
        public string  Name { get; set; }
    }
}
