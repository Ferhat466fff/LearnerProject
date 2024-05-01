using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System.Data.Entity;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {//ANA SAYFA
        LearnerContext db = new LearnerContext();

        public ActionResult Index()
        {
            return View();
        }

        //Kurs Listeleme  Review(Puan)Hesaplayıp  ve toplam kurs gosterme.
        public PartialViewResult DefaultCoursePartial()
        {
            var deger = db.Courses.Count();//Toplam Kurs
            var values = db.Courses.Include(x=>x.Reviewes).OrderByDescending(x => x.CourseId).Take(3).ToList();//Eklenen Son 3 Kursu Listeleme
            ViewBag.ferhat = deger;
            return PartialView(values);
        }

        //Kurs Detaya Tıklandığında Kurs Bilgileri Getirilsin.
        public ActionResult CourseDetial(int id)
        {
            var values = db.Courses.Find(id);
            var reviewlist = db.Reviews.Where(x => x.CourseId ==id).ToList();
            ViewBag.review = reviewlist;
            return View(values);
        }

        //Kategorileri Listeleme
        public PartialViewResult CategoryPartial()
        {
            
            var values = db.Categoryies.Where(x => x.Status==true).ToList();
            return PartialView(values);
        }
        //Kursları Listeleme
        public PartialViewResult CoursePartial()
        {

            var values = db.Courses.ToList();
            return PartialView(values);
        }
        //Hakkımda Bölümü(Toplam Öğrenci-Öğretmen)Getirme
        public PartialViewResult AboutUsPartial()
        {


            var values = db.Abouts.ToList();
            return PartialView(values);
        }
        //Testimonial(Referanslarım)Alanı Listeleme
        public PartialViewResult TestimonialPartial()
        {

            var values = db.Testimonials.ToList();
            return PartialView(values);
        }
        //Sık Sorulan Sorular Alanı
        public PartialViewResult askedPartial()
        {
            var values = db.FAQs.Where(x => x.Status==true).ToList();
            return PartialView(values);
        }

        //Banner(Afiş) Listeleme
        public PartialViewResult BannerPartiall()
        {
            var values = db.Banners.ToList();
            return PartialView(values);
        }


    





    }
}
