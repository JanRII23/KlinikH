using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;

namespace KlinikH.Web.Areas.Identity.AccountBundle.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/

        //TODO: this was just a POC don't actually make it like so
        public IActionResult Register()
        {
            return View(CustomViewHelper.DefineCustomIdentityRoute("AccountBundle", "Register"));
        }
    }
}
