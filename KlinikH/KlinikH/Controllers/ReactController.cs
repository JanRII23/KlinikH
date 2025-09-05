using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KlinikH.Web.Controllers
{
    public class ReactController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ReactController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{*url}", Order = 999)] // catch all routes
        [AllowAnonymous]
        public IActionResult Index()
        {
            var file = Path.Combine(_env.WebRootPath, "ReactApp", "index.html");
            return PhysicalFile(file, "text/html");
        }

    }
}
