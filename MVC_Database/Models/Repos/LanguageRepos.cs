using MVC_Database.Models.Services;
using MVC_Database.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Models.Repos
{
    public class LanguageRepos:ILanguageService
    {
        private readonly AppDbContext appDbContext;

        public LanguageRepos(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            List<Language> list = appDbContext.Language.ToList();


            foreach (Language item in list)
            {
                item.LanguagePersons = appDbContext.LangugePerson.Where(lp => item.Name == lp.LanguageId).ToList();
            }

            return list;
        }

        public List<string> GetUserByLanguage(string user)
        {
            List<string> users =
                ((from lp in appDbContext.LangugePerson
                  join p in appDbContext.People on
                     lp.PersonId equals p.Id
                  where lp.LanguageId == user
                  select p.Name)).ToList();

            return users;
        }

        bool ILanguageService.CreateLanguage(LanguageViewModel lVM)
        {
            Language language = new() { Name = lVM.Language };
            try
            {
                appDbContext.Language.Add(language);
                appDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        void ILanguageService.Delete(string idToRemove)
        {
            List<Language> list = appDbContext.Language.ToList();
            Language language = list.First( l => l.Name == idToRemove);
            appDbContext.Language.Remove(language);
            appDbContext.SaveChanges();
        }

    }
}
