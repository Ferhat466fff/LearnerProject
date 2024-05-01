using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        //Öğrencinin Kayıtlı Olduğu Kurslarını Lisleyeceği Alan

        LearnerContext db = new LearnerContext();

        //Kayıtlı Kurs Listeleme
        public ActionResult Index()
        {
            var studentName = Session["StudentName"].ToString();
            var student = db.Students.Where(x => x.NameSurname == studentName.ToString()).Select(x => x.StudentId).FirstOrDefault();
            var values = db.CourseRegisters.Where(x=>x.StudentId==student).ToList();
            //kayıt olunan kurslar alanı(courseregister) öğrencimizin G isiminde eşitse getirsin.
            return View(values);
        }

        //Kurs Detay Sayafsı
        public ActionResult MyCourseList(int id)
        {
            var values = db.CourseVideos.Where(x => x.CourseId == id).ToList();
            return View(values);

        }





    }
}