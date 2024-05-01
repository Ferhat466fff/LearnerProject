using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class StudentReviewController : Controller
    {///Admin Kısmı

        LearnerContext db = new LearnerContext();



        
        public ActionResult Index()
        {
            var values = db.Reviews.ToList();
            return View(values);
        }

        public ActionResult AddStudentReview()
        {
            List<SelectListItem> courses = (from x in db.Courses.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseId.ToString()
                                            }).ToList();
            ViewBag.courses = courses;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentReview(Review review)
        {
            string nameSurname = Session["studentName"].ToString();
            var studentId = db.Students.Where(x => x.NameSurname == nameSurname).Select(x => x.StudentId).FirstOrDefault();
            review.StudentId = studentId;
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}