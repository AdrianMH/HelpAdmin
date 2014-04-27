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
    public class EmployeeController : Controller
    {
        private HelpAdminEntities db = new HelpAdminEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,NextMedialExam,PhoneNumber,BirthDate")] EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee=new Employee();

                employee.EmployeeID = employeeViewModel.EmployeeID;
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.NextMedicalExam = employeeViewModel.NextMedicalExam;
                employee.PhoneNumber = employeeViewModel.PhoneNumber;
                employee.BirthDate = employeeViewModel.BirthDate;
                

                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeViewModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                NextMedicalExam = employee.NextMedicalExam,
                PhoneNumber=employee.PhoneNumber,
                BirthDate=employee.BirthDate
                

            };

           return View(employeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,NextMedialExam,PhoneNumber,BirthDate")] EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = db.Employee.Find(employeeViewModel.EmployeeID);

                employee.EmployeeID = employeeViewModel.EmployeeID;
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.NextMedicalExam = employeeViewModel.NextMedicalExam;
                employee.PhoneNumber = employeeViewModel.PhoneNumber;
                employee.BirthDate = employeeViewModel.BirthDate;
                

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
