using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminDasboardController : Controller
    {
        //İstatislikler



        LearnerContext Db = new LearnerContext();
        //Grafikler Listeleme
        public ActionResult Index()
        {
            ViewBag.v1 = Db.Courses.Count();
            ViewBag.v2 = Db.Categoryies.Count();
            ViewBag.v3 = Db.Classrooms.Count();
            ViewBag.v4 = Db.Students.Count();// OrderByDescending-->yüksekten düşüğe sıralıyor.
            ViewBag.v5 = Db.Courses.OrderByDescending(x=>x.Price).Select(x=>x.CourseName).FirstOrDefault();//en pahalı kurs-->fiayat gore sırala ismi al ve ilk değeri getir
            ViewBag.v6 = Db.Courses.Where(x => x.Category.CategoryName== "Kodlama").Count();//kodalama kursu sayısı
            ViewBag.v7 = Db.Reviews.OrderByDescending(x => x.ReviewValue).Select(x => x.Course.CourseName).FirstOrDefault();//en beğenilen kurs sayısı
            ViewBag.v8 = Db.Students.Count();
            return View();
        }
    }
}