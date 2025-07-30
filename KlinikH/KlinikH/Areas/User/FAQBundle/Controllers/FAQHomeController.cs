using Microsoft.AspNetCore.Mvc;
using KlinikH.Application.Helpers;

namespace KlinikH.Web.Areas.User.FAQBundle.Controllers
{
    [Area("User")]
    public class FAQHomeController : Controller
    {
        //TODO: is there a better way to define helper?
        public IActionResult Index()
        {
            return View(CustomViewHelper.DefineCustomUserRoute("FAQBundle", "Index"));
        }
    }
}
