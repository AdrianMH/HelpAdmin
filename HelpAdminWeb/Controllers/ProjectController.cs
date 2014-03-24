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
    public class ProjectController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.Project.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,Name")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project= new Project();

                project.ProjectID = projectViewModel.ProjectID;
                project.Name = projectViewModel.Name;

                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectViewModel);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ProjectViewModel projectViewModel = new ProjectViewModel()
            {
                ProjectID = project.ProjectID,
                Name = project.Name,
            };
            
            return View(projectViewModel);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,Name")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = db.Project.Find(projectViewModel.ProjectID);

                project.ProjectID = projectViewModel.ProjectID;
                project.Name = projectViewModel.Name;

                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(projectViewModel);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Project.Find(id);
            db.Project.Remove(project);
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
