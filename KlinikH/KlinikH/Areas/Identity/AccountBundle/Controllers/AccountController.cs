using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;

namespace KlinikH.Web.Areas.Identity.AccountBundle.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/

        //TODO: remove later
        public IActionResult Register()
        {
            return View(CustomViewHelper.DefineCustomIdentityRoute("AccountBundle", "Register"));
        }
    }
}
