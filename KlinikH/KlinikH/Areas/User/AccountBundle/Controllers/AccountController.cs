using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;
using KlinikH.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace KlinikH.Web.Areas.User.AccountBundle.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
		private readonly ILogger<AccountController> _logger;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Register"));
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                //TODO: this actually needs to be refactored don't map the username to the email
                //TODO: test the fail state

                //TODO: also this needs to be the either user or admin user
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home", new {area = ""});
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //TODO: how can I define the view to pass in the model here?
            //return View(model);
            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Register"));
        }

        //TODO: very important the logout is a POST and NOT a GET request
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
			_logger.LogInformation("User logged out.");
         
            //TBH just consider a toast message here when clicking logout to trigger instead 
            return RedirectToAction("Index", "Home", new { area = "" });
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Login"));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Login"));
        }
    }
}
