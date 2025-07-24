using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital.Web.Areas.Doctor.Controllers
{
    [Area("doctor")]
    public class DoctorsController : Controller
    {
        private IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            var morningShiftStart = new List<SelectListItem>
            {
                new SelectListItem { Value = "6:00", Text = "6:00 AM" },
                new SelectListItem { Value = "7:00", Text = "7:00 AM" },
                new SelectListItem { Value = "8:00", Text = "8:00 AM" }
            };

            var morningShiftEnd = new List<SelectListItem>
            {
                new SelectListItem { Value = "10:00", Text = "10:00 AM" },
                new SelectListItem { Value = "11:00", Text = "11:00 AM" },
                new SelectListItem { Value = "12:00", Text = "12:00 PM" }
            };

            var afternoonShiftStart = new List<SelectListItem>
            {
                new SelectListItem { Value = "13:00", Text = "1:00 PM" },
                new SelectListItem { Value = "14:00", Text = "2:00 PM" },
                new SelectListItem { Value = "15:00", Text = "3:00 PM" }
            };

            var afternoonShiftEnd = new List<SelectListItem>
            {
                new SelectListItem { Value = "17:00", Text = "5:00 PM" },
                new SelectListItem { Value = "18:00", Text = "6:00 PM" },
                new SelectListItem { Value = "19:00", Text = "7:00 PM" }
            };

            ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
            ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
            ViewBag.eventStart = new SelectList(afternoonShiftStart, "Value", "Text");
            ViewBag.eventEnd = new SelectList(afternoonShiftEnd, "Value", "Text");
            TimingViewModel vm = new TimingViewModel();
            vm.ScheduleDate = DateTime.Now;
            vm.ScheduleDate = vm.ScheduleDate.AddDays(1);

            return View(vm);
        }

        [HttpGet]
        public IActionResult AddTiming()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var Claims = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (Claims != null)
            {
                _doctorService.AddTiming(vm);
                vm.Doctor.Id = Claims.Value;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetTimingById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TimingViewModel vm)
        {
            _doctorService.UpdateTiming(vm);
            return RedirectToAction("Index");
        }

    }
}
