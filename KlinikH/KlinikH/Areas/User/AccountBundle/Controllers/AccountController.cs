using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;
using KlinikH.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using KlinikH.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;

//TODO: also how do I register/login by email (gmail)?

namespace KlinikH.Web.Areas.User.AccountBundle.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
		private readonly ILogger<AccountController> _logger;
        private readonly IDataProtector _protector;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger, IDataProtectionProvider provider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
            _protector = provider.CreateProtector("ReturnUrlProtector");
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
                var user = new AppUser { UserName = model.Username, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    user.LastLogin = DateTime.Now;
                    await userManager.UpdateAsync(user);

                    //TODO: if associated with a cookie need to actually do refreshSignInAsync

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

        //TODO: https://dotnetdocs.ir/Post/26/how-to-use-remote-attribute-in-aspnet-core response cache?
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            //TODO: how do I extend this method also how do I handle for collisions
                
            var user = await userManager.FindByEmailAsync(email);

            if (user == null) {
                return Json(true);
            } else {
                return Json($"Email {email} is already in use");
            }
            //TODO: this is bounded by the "Remote" clause in the registerViewModel for validation on focusout (i.e. client side validation)
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            //TODO: account for in-use but also for whether its valid?
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Json(true);
            } else
            {
                return Json($"Username {username} is already in use");
            }
        }

        //NOTE: very important the logout is a POST and NOT a GET request
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
			_logger.LogInformation("User logged out.");
         
            //TBH just consider a toast message here when clicking logout to trigger instead 
            return RedirectToAction("Index", "Home", new { area = "" });
            
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/")
        {
            ViewData["ReturnUrl"] = _protector.Protect(ReturnUrl);
            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Login"));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //TODO: validate against all bundles, trim any https, and maybe just the home workflow 
                    var user = await userManager.FindByNameAsync(model.Username);
                    if (user != null)
                    {
                        user.LastLogin = DateTime.Now;
                        await userManager.UpdateAsync(user);
                    }
                    var decodedReturnUrl = _protector.Unprotect(ReturnUrl);

                    if (!string.IsNullOrEmpty(decodedReturnUrl) && Url.IsLocalUrl(decodedReturnUrl))
                    {
                        return Redirect(decodedReturnUrl);
                    } else
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(CustomViewHelper.DefineCustomUserRoute("AccountBundle", "Login"));
        }
    }
}
