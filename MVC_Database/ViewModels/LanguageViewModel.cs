using MVC_Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Database.ViewModels
{
    public class LanguageViewModel
    {
        //public IEnumerable<Language> languageList;
        //
        [Required(ErrorMessage = "Sluta nu Simon/Jonathan/Tobias Namn är Obligerat")]
        [StringLength(100, MinimumLength = 2)]
        public string Language { get; set; }
    }
}
