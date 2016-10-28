using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuanLySinhVien.Data;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;
using QuanLySinhVien.Service;

namespace QuanLySinhVien.Web.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        private QuanLySinhVienDbContext db = new QuanLySinhVienDbContext();

        // GET: Admin/Students
        public ActionResult Index(
                   bool? filter,
                   string searchString,

                   bool? currentlySelectedFilterParam,
                   string currentSearchStringParam,
                   string sortOrderParam,

                   int? page)
        {

            if (filter.HasValue && !string.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else if (filter.HasValue)
            {
                page = 1;
                searchString = currentSearchStringParam;
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
                filter = currentlySelectedFilterParam;
            }
            else
            {
                filter = currentlySelectedFilterParam;
                searchString = currentSearchStringParam;
            }


            var studentList = _studentService.GetByFilterSearchSort(filter, searchString, sortOrderParam);

            ViewBag.CurrentSearchString = searchString;
            PoupulateIsEnrolled(filter);
            ViewBag.CurrentlySelectedIsEnrolled = filter;
            ViewBag.sortOrderParam = sortOrderParam;

            ViewBag.IdSortParm = string.IsNullOrEmpty(sortOrderParam) ? "Id" : "";
            ViewBag.FirstNameSortParm = string.IsNullOrEmpty(sortOrderParam) ? "FirstName" : "";
            ViewBag.EnrollmentDateSortParm = string.IsNullOrEmpty(sortOrderParam) ? "EnrollmentDate" : "";

            return View(studentList.ToPagedList(page ?? 1, 2));
        }


        private void PoupulateIsEnrolled(bool? selectedFilter)
        {
            var list = new List<SelectListItem>
                {
                    new SelectListItem{ Text="Course Enrolled", Value = "true"},
                    new SelectListItem{ Text="Not Course Erolled", Value = "false" },
                };
            ViewBag.CurrentFilteredListWithSelectedItem = new SelectList(list, "Value", "Text", selectedFilter);
        }

        // GET: Admin/Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = _studentService.GetById(id);
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
                _studentService.Add(student);
                _studentService.Save();
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
            Student student = _studentService.GetById(id);
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
                _studentService.Update(student);
                _studentService.Save();
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
            Student student = _studentService.GetById(id);
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
            _studentService.Delete(id);
            _studentService.Save();
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
