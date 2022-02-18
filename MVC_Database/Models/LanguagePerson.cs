using System.ComponentModel.DataAnnotations;

namespace MVC_Database.Models
{
    public class LanguagePerson
    {
        [Key]
        public int PersonId { get; set; }
        [Key]
        public string LanguageId { get; set; }

        public Person Person;
        public Language Language;

    }
}
