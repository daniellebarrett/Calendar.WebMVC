using Calendar.Data;
using Calendar.Models;
using Calendar.Services;
using Microsoft.AspNet.Identity;
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
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Appointment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            var model = service.GetAppointments();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new ClientService(userId);
                
            ViewBag.ClientId = new SelectList(service.GetClients(), "ClientId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAppointmentService();

            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Appointment could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model =
                new AppointmentEdit
                {
                    AppointmentID = detail.AppointmentID,
                    AppointmentDate= detail.AppointmentDate,
                    StartTime = detail.StartTime,
                    EndTime = detail.EndTime,
                    TypeOfAppointment = detail.TypeOfAppointment,
                    AppointmentReason = detail.AppointmentReason,
                    ClientId = detail.ClientId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AppointmentID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAppointmentService();

            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your appointment could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAppointmentService();

            service.DeleteAppointment(id);

            TempData["SaveResult"] = "Your appointment was deleted";

            return RedirectToAction("Index");
        }

        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            return service;
        }
    }
}