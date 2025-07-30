using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;

namespace KlinikH.Web.Areas.User.ContactBundle.Controllers
{
    [Area("User")]
    public class ContactHomeController : Controller
    {
        public IActionResult Index()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("ContactBundle", "Index"));
        }
    }
}
