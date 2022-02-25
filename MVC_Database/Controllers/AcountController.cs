using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;
using MVC_Database.ViewModels;
using System.Threading.Tasks;

namespace MVC_Database.Controllers
{
    public class AcountController : Controller
    {
        readonly  UserManager<ApplicationUser>  userManager;
        readonly SignInManager<ApplicationUser> signInManager;

        public AcountController(UserManager <ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager; 
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateUserAsync(LoginViewModel loginViewModel)
        {
            ApplicationUser user = new() { UserName = loginViewModel.UserName };
            IdentityResult result = await userManager.CreateAsync(user,loginViewModel.Password); 

            return View();
        }

        //public async void SignIn()
        //{ 
        //    SignInResult  sr = await signInManager.PasswordSignInAsync(User,)
        //}

 //       public async void SignOut()
 //       { 
 ////           await SignInManager.SignOutAsync();
        
 //       }



    }
}
