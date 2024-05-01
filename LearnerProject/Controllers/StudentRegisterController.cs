using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;


namespace LearnerProject.Controllers
{
    public class StudentRegisterController : Controller
    {
        //Öğrenci Kayıt

        LearnerContext db =new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index", "StudentLogin");
        }
    }
}