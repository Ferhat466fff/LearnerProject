using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
        LearnerContext db = new LearnerContext();

        //1.Aşama-->Öğrenci Giriş Yapacak 
        //2.Aşama-->CourseRegister(Kurs Kaydı) Sayfasına Gidecek 


        //Öğrenci Giriş Yaptı.Kurs Seçecek
        [HttpGet]
        public ActionResult Index()
            //Kursları Listeleme
        { var courselist = db.Courses.ToList();
            List<SelectListItem> courses = (from x in courselist
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseId.ToString()

                                            }).ToList();
            ViewBag.course = courses;
            return View();
        }
        [HttpPost]
        public ActionResult Index(CourseRegister CourseRegister )
        {

            string student = Session["StudentName"].ToString();
            CourseRegister.StudentId = db.Students.Where(x => x.NameSurname == student).Select(x => x.StudentId).FirstOrDefault();
            db.CourseRegisters.Add(CourseRegister);
            db.SaveChanges();
            return RedirectToAction("Index","StudentCourse");
        }

        public ActionResult RegisterStudentList()
        {
            var values = db.CourseRegisters.ToList();
            return View(values);
        }
    }
}