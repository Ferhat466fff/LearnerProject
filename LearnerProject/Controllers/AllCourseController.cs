using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;
using System.Data.Entity;
using System.Net;
using PagedList;
using PagedList.Mvc;


namespace LearnerProject.Controllers
{
    public class AllCourseController : Controller
    {
        LearnerContext db = new LearnerContext();

        //Tüm Kursları Listeleme
        public ActionResult Index(int sayfa=1)
        {
          
            var deger = db.Courses.Count();//Toplam Kurs
            var values = db.Courses.Include(x => x.Reviewes).OrderByDescending(x => x.CourseId).ToList().ToPagedList(sayfa, 6);
            ViewBag.ferhat = deger;
            return PartialView(values);
        }
    }
}