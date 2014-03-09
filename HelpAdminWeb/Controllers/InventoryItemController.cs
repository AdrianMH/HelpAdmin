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
    public class InventoryItemController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: InventoryItem
        public ActionResult Index()
        {
            var inventoryItem = db.InventoryItem.Include(i => i.Client).Include(i => i.InventoryCategory);
            return View(inventoryItem.ToList());
        }

        // GET: InventoryItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = db.InventoryItem.Find(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItem);
        }

        // GET: InventoryItem/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Client, "ClientID", "Name");
            ViewBag.CategoryID = new SelectList(db.InventoryCategory, "InventoryCategoryID", "Name");
            return View();
        }

        // POST: InventoryItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryItemID,Name,Details,SerialNumber,SupplierID,CategoryID")] InventoryItemViewModel inventoryItemViewModel)
        {
            if (ModelState.IsValid)
            {
                InventoryItem inventoryItem=new InventoryItem();

                inventoryItem.InventoryItemID = inventoryItemViewModel.InventoryItemID;
                inventoryItem.Name = inventoryItemViewModel.Name;
                inventoryItem.Details = inventoryItemViewModel.Details;
                inventoryItem.SerialNumber = inventoryItemViewModel.SerialNumber;
                inventoryItem.SupplierID = inventoryItemViewModel.SupplierID;
                inventoryItem.CategoryID = inventoryItemViewModel.CategoryID;
                inventoryItem.Code = inventoryItemViewModel.Code;

                db.InventoryItem.Add(inventoryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Client, "ClientID", "Name", inventoryItemViewModel.SupplierID);
            ViewBag.CategoryID = new SelectList(db.InventoryCategory, "InventoryCategoryID", "Name", inventoryItemViewModel.CategoryID);
            return View(inventoryItemViewModel);
        }

        // GET: InventoryItem/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = db.InventoryItem.Find(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }

            InventoryItemViewModel inventoryItemViewModel = new InventoryItemViewModel()
            {
                InventoryItemID=inventoryItem.InventoryItemID,
                Name=inventoryItem.Name,
                Details=inventoryItem.Details,
                SerialNumber=inventoryItem.SerialNumber,
                SupplierID=inventoryItem.SupplierID,
                CategoryID=inventoryItem.CategoryID,
                Code=inventoryItem.Code
            };
            ViewBag.SupplierID = new SelectList(db.Client, "ClientID", "Name", inventoryItemViewModel.SupplierID);
            ViewBag.CategoryID = new SelectList(db.InventoryCategory, "InventoryCategoryID", "Name", inventoryItemViewModel.CategoryID);
            return View(inventoryItemViewModel);
        }

        // POST: InventoryItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryItemID,Name,Details,SerialNumber,SupplierID,CategoryID")] InventoryItemViewModel inventoryItemViewModel)
        {
            if (ModelState.IsValid)
            {
                InventoryItem inventoryItem = db.InventoryItem.Find(inventoryItemViewModel.InventoryItemID);

                inventoryItem.InventoryItemID = inventoryItemViewModel.InventoryItemID;
                inventoryItem.Name = inventoryItemViewModel.Name;
                inventoryItem.Details = inventoryItemViewModel.Details;
                inventoryItem.SerialNumber = inventoryItemViewModel.SerialNumber;
                inventoryItem.SupplierID = inventoryItemViewModel.SupplierID;
                inventoryItem.CategoryID = inventoryItemViewModel.CategoryID;
                inventoryItem.Code = inventoryItemViewModel.Code;

                db.Entry(inventoryItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.Client, "ClientID", "Name", inventoryItemViewModel.SupplierID);
            ViewBag.CategoryID = new SelectList(db.InventoryCategory, "InventoryCategoryID", "Name", inventoryItemViewModel.CategoryID);
            return View(inventoryItemViewModel);
        }

        // GET: InventoryItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = db.InventoryItem.Find(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItem);
        }

        // POST: InventoryItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryItem inventoryItem = db.InventoryItem.Find(id);
            db.InventoryItem.Remove(inventoryItem);
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
