using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class StudentController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();

        //Student(Öğrenci)Listeleme
        public ActionResult Index()
        {
            var values = db.Students.ToList();
            return View(values);
        }

        //StudentEkleme
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student Student)
        {
            db.Students.Add(Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Öğrenci Silme
        public ActionResult DeleteStudent(int id)
        {

            var values = db.Students.Find(id);
            db.Students.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Öğrenci Güncelleme
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var values = db.Students.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student Student)
        {
            var values = db.Students.Find(Student.StudentId);
            values.StudentId = Student.StudentId;
            values.NameSurname = Student.NameSurname;
            values.UserName = Student.UserName;
            values.Password = Student.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}