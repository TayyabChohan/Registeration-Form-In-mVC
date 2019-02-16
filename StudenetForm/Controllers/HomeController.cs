using StudenetForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudenetForm.Controllers
{
    public class HomeController : Controller
    {
        StudentRegisterationFromEntities db = new StudentRegisterationFromEntities();
        public ActionResult Index()
        {
            var list = db.studentInfoes.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            BindDropDownFOrCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Create(studentInfo st)
        {
            db.studentInfoes.Add(st);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private void BindDropDownFOrCategory()
        {
            var SchoolYearslist = db.SchoolYears.ToList();
            List<SelectListItem> schoolyearlist = new SelectList(SchoolYearslist, "YearId", "Name_Of_school_Year").ToList();
            ViewBag.schoolyearlistBag = schoolyearlist;

            var Status = db.StatusOfStudents.ToList();
            List<SelectListItem> statusList = new SelectList(Status, "StatusId", "Student_status").ToList();
            ViewBag.statusListBag = statusList;

            var ClassYearlist = db.ClassYears.ToList();
            List<SelectListItem> YearList = new SelectList(ClassYearlist, "class_YearsId", "Name_Of_Year").ToList();
            ViewBag.YearListBag = YearList;

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BindDropDownFOrCategory();
             studentInfo stinfo= db.studentInfoes.Find(id);
            return View(stinfo);
        }
        [HttpPost]
        public ActionResult Edit(studentInfo emp, int id)
        {
            BindDropDownFOrCategory();
            studentInfo emp1 = db.studentInfoes.SingleOrDefault(m => m.studentId == id);
            emp1.studentId = emp.studentId;
            emp1.YearId = emp.YearId;
            emp1.FirstName = emp.FirstName;
            emp1.LastName = emp.LastName;
            emp1.MiddleName = emp.MiddleName;
            emp1.S_Adress = emp.S_Adress;
            emp1.Date_Of_Birth = emp.Date_Of_Birth;
            emp1.Place_Of_Birth = emp.Place_Of_Birth;
            emp1.Age = emp.Age;
            emp1.Gender = emp.Gender;
            emp1.studentId = emp.studentId;
            emp1.class_YearsId = emp.class_YearsId;
            emp1.Guardian = emp.Guardian;
            emp1.Relation = emp.Relation;
            emp1.G_Address = emp.G_Address;
            emp1.Contact = emp.Contact;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            studentInfo emp = db.studentInfoes.Find(id);
            if (emp == null)
            {
                HttpNotFound();
            }

            return View(emp);
        }
        public ActionResult Delete(int id)
        {

            studentInfo emp = db.studentInfoes.Find(id);
            db.studentInfoes.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}