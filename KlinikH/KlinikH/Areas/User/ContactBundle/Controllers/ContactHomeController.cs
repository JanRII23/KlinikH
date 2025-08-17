using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace KlinikH.Web.Areas.User.ContactBundle.Controllers
{
    [Area("User")]
    public class ContactHomeController : Controller
    {
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("ContactBundle", "Index"));
        }
    }
}
