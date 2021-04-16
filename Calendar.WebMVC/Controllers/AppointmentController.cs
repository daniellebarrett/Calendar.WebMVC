using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar.WebMVC.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            var model = new AppointmentListItem[0];
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (AppointmentCreate model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}