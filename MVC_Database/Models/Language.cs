using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Database.Models
{
    public class Language
    {
        [Key]
        public string Name { get; set; }

        public List<LanguagePerson> LanguagePersons { get; set; }

    }
}
