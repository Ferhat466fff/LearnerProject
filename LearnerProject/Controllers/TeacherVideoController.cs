using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class TeacherVideoController : Controller
    {
        LearnerContext db = new LearnerContext();
        public ActionResult Index()
        {
            string teachernamesurname = Session["teacherName"].ToString();
            var teacher = db.Teachers.Where(x => x.NameSurname == teachernamesurname).FirstOrDefault();
            var teachercourses = db.Courses.Where(x => x.TeacherId == teacher.TeacherId).Select(x => x.CourseId).ToList();
            var teachervideos = db.CourseVideos.Where(x => teachercourses.Contains(x.CourseId) == true).ToList();
            return View(teachervideos);
        }

        [HttpGet]
        public ActionResult AddVideo()
        {
            List<SelectListItem> video = (from x in db.CourseVideos.ToList()
                                             select new SelectListItem//kategoriler içerisinde seçimler yapacağız
                                             {
                                                 Text = x.Course.CourseName,//displaymember(gözükecek deger)
                                                 Value = x.CourseVideoId.ToString()//valuemember gibi düşün(arkada dönen deger)
                                             }).ToList();

            ViewBag.video = video;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır
            return View();
        }
        [HttpPost]
        public ActionResult AddVideo(CourseVideo video)
        {
            db.CourseVideos.Add(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }








    }
}