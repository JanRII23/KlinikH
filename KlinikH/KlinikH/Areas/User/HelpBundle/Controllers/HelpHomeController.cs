using KlinikH.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KlinikH.Web.Areas.User.HelpBundle.Controllers
{
    [Area("User")]
    public class HelpHomeController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("HelpBundle", "Index"));
        }
    }
}
