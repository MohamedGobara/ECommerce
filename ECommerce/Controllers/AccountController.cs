using ECommerce.Data;
using ECommerce.Data.ViewModel;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECommerceDBContext _context;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public AccountController(ECommerceDBContext context , SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signinManager = signinManager;
            _userManager = userManager;
        }



        public IActionResult Login()
        {
            var loginResult = new LoginVM();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginModel)
        {
            if (!ModelState.IsValid) {

                return View(loginModel);
                   }
            var user = await _userManager.FindByEmailAsync(loginModel.EmailAddress);
            if (user!=null) { 
            
            var passwordCheck  = await _userManager.CheckPasswordAsync(user, loginModel.Password);

                if (passwordCheck) {


                    var signinResult = await _signinManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (signinResult.Succeeded) {


                        return RedirectToAction("Index", "Products");
                    }
                
                
                }

            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);


        }

        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(model);
            }

            var newUser = new ApplicationUser
            {
                UserName = model.EmailAddress,
                Email = model.EmailAddress,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                await _signinManager.SignInAsync(newUser, isPersistent: false);
                return RedirectToAction("Index", "Products");
            }
           
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
