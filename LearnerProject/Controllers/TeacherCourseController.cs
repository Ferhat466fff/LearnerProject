using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        //TeacherLogin Öğretmen giriş yaptı.
        //ve biz bu tarafta bu ifadeyi kullanarak öğretmenin adını ve soyadını aldık. Session["teacherName"] = values.NameSurname;
        //Nu sayede aşağıda listeleme-silme-güncelleme vs işlemler yapıyoruz.
        //sessionda-->öğretmenin id-soyad tutuyor.




        //Giriş Yapan Kişinin Kendi Kurslarını Görüntuleyecegı Alan 
        LearnerContext db = new LearnerContext();

        //Oturum Acan Öğretmenin İsmine Gore Kursları Listeleme
        public ActionResult Index()
        {
            string name=Session["teacherName"].ToString();//isme göre oturum acacak(teachername-->kullanıcının teacherlogin tarafındaki isim ve soy ismi)
            var values = db.Courses.Where(x => x.Teacher.NameSurname == name).ToList();//isme gore kursları listeleycek
            return View(values);
        }

        //Oturum Acan Öğretmenin İsmine Gore Kursları Silme
         public ActionResult DeleteCourse(int id)
        {
            var values = db.Courses.Find(id);
            db.Courses.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Oturum Acan Öğretmenin İsmine Gore Kurs Ekleme ve kategorileri getirme
        [HttpGet]
        public ActionResult AddCourse()
        {   //kategorileri getirme
            List<SelectListItem> category = (from x in db.Categoryies.Where(x => x.Status == true).ToList()
                                             select new SelectListItem//kategoriler içerisinde seçimler yapacağız
                                             {
                                                 Text = x.CategoryName,//displaymember(gözükecek deger)
                                                 Value = x.CategoryId.ToString()//valuemember gibi düşün(arkada dönen deger)
                                             }).ToList();

            ViewBag.category = category;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır
            return View();
           
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            string name = Session["teacherName"].ToString();//teachername-->kullanıcının teacherlogin tarafındaki isim ve soy ismi
            course.TeacherId = db.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();//oturum Açan öğretmenin Id aldık.
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Kategori Verilerini Getirme Ve Kurs Güncelleme
        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> category = (from x in db.Categoryies.Where(x => x.Status == true).ToList()//durumu true olanları listele
                                             select new SelectListItem//kategoriler içerisinde seçimler yapacağız
                                             {
                                                 Text = x.CategoryName,//displaymember(gözükecek deger)
                                                 Value = x.CategoryId.ToString()//valuemember gibi düşün(arkada dönen deger)
                                             }).ToList();

            ViewBag.category = category;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır
            var value = db.Courses.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateCourse(Course Course)
        {
            var value = db.Courses.Find(Course.CourseId);
            string name = Session["teacherName"].ToString();//teachername-->kullanıcının teacherlogin tarafındaki isim ve soy ismi
            value.TeacherId = db.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();//oturum Açan öğretmenin Id aldık.

            value.CategoryId = Course.CategoryId;
            value.CourseName = Course.CourseName;
            value.ImageUrl = Course.ImageUrl;
            value.Price = Course.Price;
            value.Description = Course.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }









    }
}