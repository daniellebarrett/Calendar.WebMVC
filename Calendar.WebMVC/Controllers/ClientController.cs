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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetClients();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your client was created.";
                return RedirectToAction("Index");
            };

           ModelState.AddModelError("", "Client could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientID = detail.ClientID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ClientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();
            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your client was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your client could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int id)
        {
            var service = CreateClientService();

            service.DeleteClient(id);

            TempData["SaveResult"] = "Your client was deleted";
            return RedirectToAction("Index");
        }
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
    }
}