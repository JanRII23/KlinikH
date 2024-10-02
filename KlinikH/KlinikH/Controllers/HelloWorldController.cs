using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Encodings.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KlinikH.Controllers
{
    public class HelloWorldController : Controller
    {
        //TODO: believe the IActionResult returns the view
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/ the base action
        //public string Index()
        //{
        //    //return "This is my default action...";
        //}
        // 
        // GET: /HelloWorld/Welcome/ extended action
        //HelloWorld/Welcome/3?name=Rick -> in this particular case the the trailing slash define which controllers are called but the ? is the seperator which can pass in the argument
        //public string Welcome(string name, int ID = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            /*The view model approach to passing data is preferred over the ViewData dictionary approach.*/
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
