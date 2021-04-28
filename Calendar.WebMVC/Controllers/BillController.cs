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
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BillService(userId);
            var model = service.GetBills();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BillCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBillService();

            if (service.CreateBill(model))
            {
                TempData["SaveResult"] = "Your bill was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Bill could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBillService();
            var model = svc.GetBillById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBillService();
            var detail = service.GetBillById(id);
            var model =
                new BillEdit
                {
                    BillingID = detail.BillingID,
                    DateIssued = detail.DateIssued,
                    DateDue = detail.DateDue,
                    BillStatus = detail.BillStatus,
                    BillAmount = detail.BillAmount,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BillEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BillingID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBillService();
            if (service.UpdateBill(model))
            {
                TempData["SaveResult"] = "Your bill was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your bill could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBillService();
            var model = svc.GetBillById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBill(int id)
        {
            var service = CreateBillService();

            service.DeleteBill(id);

            TempData["SaveResult"] = "Your bill was deleted";
            return RedirectToAction("Index");
        }

        private BillService CreateBillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BillService(userId);
            return service;
        }
    }
}