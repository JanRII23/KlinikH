using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace KlinikH.Web.Areas.User.FAQBundle.Controllers
{
    [Area("User")]
    public class FAQHomeController : Controller
    {
        //TODO: is there a better way to define helper?
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("FAQBundle", "Index"));
        }
    }
}
