using MVC_Database.ViewModels;
using System.Collections.Generic;

namespace MVC_Database.Models.Services
{
    public interface ILanguageService
    {
        public IEnumerable<Language> GetAllLanguages();
        public bool CreateLanguage(LanguageViewModel lVM);
        void Delete(string id);

        public List<string> GetUserByLanguage(string user);
    }
}
