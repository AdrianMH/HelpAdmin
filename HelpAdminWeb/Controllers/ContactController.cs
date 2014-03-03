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
    public class ContactController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: Contact
        public ActionResult Index()
        {
            var contact = db.Contact.Include(c => c.Client);
            return View(contact.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name");
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,ClientID,Surname,Forename,Email,Telephone,Details")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                Contact contact=new Contact()
                {
                    ClientID=contactViewModel.ClientID,
                    Surname=contactViewModel.Surname,
                    Forename=contactViewModel.Forename,
                    Email=contactViewModel.Email,
                    Telephone=contactViewModel.Telephone,
                    Details=contactViewModel.Details
                };
                db.Contact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", contactViewModel.ClientID);
            return View(contactViewModel);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ContactViewModel contactViewModel=new ContactViewModel()
            {
                ClientID=contact.ClientID,
                Surname=contact.Surname,
                Forename=contact.Forename,
                Email=contact.Email,
                Telephone=contact.Telephone,
                Details=contact.Details,
                ContactID = contact.ContactID
            };
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", contact.ClientID);
            return View(contactViewModel);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,ClientID,Surname,Forename,Email,Telephone,Details")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                Contact contact = db.Contact.Find(contactViewModel.ContactID);

                contact.Surname = contactViewModel.Surname;
                contact.Forename = contactViewModel.Forename;
                contact.Email = contactViewModel.Email;
                contact.Telephone = contactViewModel.Telephone;
                contact.Details = contactViewModel.Details;
                contact.ContactID = contactViewModel.ContactID;


                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", contactViewModel.ClientID);
            return View(contactViewModel);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
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
