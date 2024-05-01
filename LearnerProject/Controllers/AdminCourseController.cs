using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;


namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext Db = new LearnerContext();
        public ActionResult Index()
        {
            var values = Db.Courses.ToList();
            return View(values);
        }



        public ActionResult DeleteCourse(int id)
        {
            var value = Db.Courses.Find(id);
            Db.Courses.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Kurs Ekleme Ve Kategori Seçtirme (İLİŞKİLİ TABLOLARDA)
        [HttpGet]
        public ActionResult AddCourse()
        {//Kategori Ve Öğretmen Seçtirme
            List<SelectListItem> category = (from x in Db.Categoryies.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            List<SelectListItem> teacher = (from x in Db.Teachers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.NameSurname,
                                                Value = x.TeacherId.ToString()
                                            }).ToList();
            ViewBag.category = category;
            ViewBag.teacher = teacher;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course k)
        {   //kategori ekleme
            Db.Courses.Add(k);
            Db.SaveChanges();
            return RedirectToAction("Index");

        }



        //kategori verilerini getirme ve Kurs güncelleme
        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> category = (from x in Db.Categoryies.Where(x => x.Status == true).ToList()//durumu true olanları listele
                                             select new SelectListItem//kategoriler içerisinde seçimler yapacağız
                                             {
                                                 Text = x.CategoryName,//displaymember(gözükecek deger)
                                                 Value = x.CategoryId.ToString()//valuemember gibi düşün(arkada dönen deger)
                                             }).ToList();

            ViewBag.category = category;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır
            var value = Db.Courses.Find(id);
            return View(value);
            
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course Course)
        {
            var value = Db.Courses.Find(Course.CourseId);
            
                value.CategoryId = Course.CategoryId;
                value.CourseName = Course.CourseName;
                value.ImageUrl = Course.ImageUrl;
                value.Price = Course.Price;
                value.Description = Course.Description;
                Db.SaveChanges();
            
            return RedirectToAction("Index");
        }



        public ActionResult AboutAdd(About about)
        {
            Db.Abouts.Add(about);
            Db.SaveChanges();
            return RedirectToAction("Index");

        }

















    }
}