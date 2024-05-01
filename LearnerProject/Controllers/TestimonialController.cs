using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;
using System.IO;

namespace LearnerProject.Controllers
{
    public class TestimonialController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();



        //Tesitmonials(Referanslar)
        public ActionResult Index()
        {
            var values = db.Testimonials.ToList();
            return View(values);
        }
        //Testimonial silme
        public ActionResult DeleteTestimonial(int id)
        {
            var values=db.Testimonials.Find(id);
            db.Testimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        //Tesitimonial Güncelleme
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = db.Testimonials.Find(testimonial.TestimonialId);

            if (testimonial.ImageUrl != null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/Testimonial/" + dosyaadi + uzanti;//Image adında  bir dosya oluşturduk
                //Resmi klasörün içine atalım.
                Request.Files[0].SaveAs(Server.MapPath(yol));

                if (System.IO.File.Exists(Server.MapPath(value.ImageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath(value.ImageUrl));
                }

                value.ImageUrl = "/Image/Testimonial/" + dosyaadi + uzanti;
            }

            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}