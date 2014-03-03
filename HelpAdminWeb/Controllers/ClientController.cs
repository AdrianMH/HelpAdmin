using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpAdminData;
using HelpAdminWeb.Models;

namespace HelpAdminWeb.Controllers
{
    public class ClientController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Client.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,Name,Url,Telephone,Email,Details")] ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                Client client =new Client();

                client.Name = clientViewModel.Name;
                client.Url = clientViewModel.Url;
                client.Telephone = clientViewModel.Telephone;
                client.Email = clientViewModel.Email;
                client.Details = clientViewModel.Details;

                db.Client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientViewModel);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ClientViewModel clientViewModel=new ClientViewModel()
            {
                ClientID=client.ClientID, 
                Name = client.Name,
                Url=client.Url,
                Telephone=client.Telephone,
                Email=client.Email,
                Details=client.Details
            
            };

            return View(clientViewModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,Name,Url,Telephone,Email,Details")] ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                Client client = db.Client.Find(clientViewModel.ClientID);

                client.Name = clientViewModel.Name;
                client.Url = clientViewModel.Url;
                client.Telephone = clientViewModel.Telephone;
                client.Email = clientViewModel.Email;
                client.Details = clientViewModel.Details;

                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientViewModel);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
