using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Data;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;
using QuanLySinhVien.Service;

namespace QuanLySinhVien.Web.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        private QuanLySinhVienDbContext db = new QuanLySinhVienDbContext();

        // GET: Admin/Students
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            return View(studentService.GetAll().ToList());
        }

        // GET: Admin/Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentService.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admin/Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,EnrollmentDate,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Students.Add(student);
                //db.SaveChanges();
                studentService.Add(student);
                studentService.Save();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentService.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,EnrollmentDate,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();
                studentService.Update(student);
                studentService.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Admin/Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = studentService.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();
            studentService.Delete(id);
            studentService.Save();
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
