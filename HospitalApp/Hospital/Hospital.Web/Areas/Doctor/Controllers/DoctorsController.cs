using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Doctor.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
