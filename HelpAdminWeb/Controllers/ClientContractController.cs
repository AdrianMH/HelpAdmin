using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HelpAdminData;
using HelpAdminWeb.Models;

namespace HelpAdminWeb.Controllers
{
    public class ClientContractController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: ClientContract
        public ActionResult Index()
        {
            return View(db.ClientContract.ToList());
        }

        // GET: ClientContract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContract clientContract = db.ClientContract.Find(id);
            if (clientContract == null)
            {
                return HttpNotFound();
            }
            return View(clientContract);
        }

        // GET: ClientContract/Create
        public ActionResult Create()
        {

            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name");
            return View();
        }

        // POST: ClientContract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Month,Year,Ammount,AdditionalAmmount,ClientContractID,ClientID")] ClientContractViewModel clientContractViewModel)
        {
            if (ModelState.IsValid)
            {
                ClientContract clientContract=new ClientContract();
                
                clientContract.Month = clientContractViewModel.Month;
                clientContract.Year = clientContractViewModel.Year;
                clientContract.Ammount = clientContractViewModel.Ammount;
                clientContract.AdditionalAmmount = clientContractViewModel.Ammount;
                clientContract.ClientID = clientContractViewModel.ClientID;
                clientContract.ClientContractID = clientContractViewModel.ClientContractID;

                db.ClientContract.Add(clientContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", clientContractViewModel.ClientID);
            return View(clientContractViewModel);
        }

        // GET: ClientContract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContract clientContract = db.ClientContract.Find(id);
            if (clientContract == null)
            {
                return HttpNotFound();
            }
            ClientContractViewModel clientContractViewModel = new ClientContractViewModel()
            {
                ClientContractID=clientContract.ClientContractID,
                ClientID=clientContract.ClientID,
                Month=clientContract.Month,
                Year=clientContract.Year,
                Ammount=clientContract.Ammount,
                AdditionalAmmount=clientContract.AdditionalAmmount,
            };
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", clientContract.ClientID);
            return View(clientContractViewModel);
        }

        // POST: ClientContract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Month,Year,Ammount,AdditionalAmmount,ClientContractID,ClientID")] ClientContractViewModel clientContractViewModel)
        {
            if (ModelState.IsValid)
            {
                ClientContract clientContract = db.ClientContract.Find(clientContractViewModel.ClientContractID);

                clientContract.ClientContractID = clientContractViewModel.ClientContractID;
                clientContract.Month = clientContractViewModel.Month;
                clientContract.Year = clientContractViewModel.Year;
                clientContract.Ammount = clientContractViewModel.Ammount;
                clientContract.AdditionalAmmount = clientContractViewModel.AdditionalAmmount;
                clientContract.ClientID = clientContractViewModel.ClientID;

                db.Entry(clientContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "Name", clientContractViewModel.ClientID);
            return View(clientContractViewModel);
        }

        // GET: ClientContract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContract clientContract = db.ClientContract.Find(id);
            if (clientContract == null)
            {
                return HttpNotFound();
            }
            return View(clientContract);
        }

        // POST: ClientContract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientContract clientContract = db.ClientContract.Find(id);
            db.ClientContract.Remove(clientContract);
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
