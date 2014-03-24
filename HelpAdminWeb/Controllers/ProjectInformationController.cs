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
    public class ProjectInformationController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: ProjectInformation
        public ActionResult Index()
        {
            var projectInformation = db.ProjectInformation.Include(p => p.Project);
            return View(projectInformation.ToList());
        }

        // GET: ProjectInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInformation projectInformation = db.ProjectInformation.Find(id);
            if (projectInformation == null)
            {
                return HttpNotFound();
            }
            return View(projectInformation);
        }

        // GET: ProjectInformation/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name");
            return View();
        }

        // POST: ProjectInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectInformationID,ProjectID,Description")] ProjectInformationViewModel projectInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectInformation projectInformation = new ProjectInformation();

                projectInformation.ProjectInformationID = projectInformationViewModel.ProjectInformationID;
                projectInformation.ProjectID = projectInformationViewModel.ProjectID;
                projectInformation.Description = projectInformationViewModel.Description;

                db.ProjectInformation.Add(projectInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", projectInformationViewModel.ProjectID);
            return View(projectInformationViewModel);
        }

        // GET: ProjectInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInformation projectInformation = db.ProjectInformation.Find(id);
            if (projectInformation == null)
            {
                return HttpNotFound();
            }
            ProjectInformationViewModel projectInformationViewModel = new ProjectInformationViewModel()
            {
                ProjectInformationID=projectInformation.ProjectInformationID,
                ProjectID=projectInformation.ProjectID,
                Description=projectInformation.Description
            };
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", projectInformation.ProjectID);
            return View(projectInformationViewModel);
        }

        // POST: ProjectInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectInformationID,ProjectID,Description")] ProjectInformationViewModel projectInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectInformation projectInformation = db.ProjectInformation.Find(projectInformationViewModel.ProjectInformationID);

                projectInformation.ProjectInformationID = projectInformationViewModel.ProjectInformationID;
                projectInformation.ProjectID = projectInformationViewModel.ProjectID;
                projectInformation.Description = projectInformationViewModel.Description;

                db.Entry(projectInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", projectInformationViewModel.ProjectID);
            return View(projectInformationViewModel);
        }

        // GET: ProjectInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInformation projectInformation = db.ProjectInformation.Find(id);
            if (projectInformation == null)
            {
                return HttpNotFound();
            }
            return View(projectInformation);
        }

        // POST: ProjectInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectInformation projectInformation = db.ProjectInformation.Find(id);
            db.ProjectInformation.Remove(projectInformation);
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
