using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class FAQSController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();



        //Sık Soru Listeleme(Listeleme)
        public ActionResult Index()
        {
            var values = db.FAQs.ToList();
            return View(values);
        }

        //Sık Soru Listeleme Ekeleme
        [HttpGet]
        public ActionResult AddFAQS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQS(FAQ FAQS)
        {
            db.FAQs.Add(FAQS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Sık Soru Silme
        public ActionResult DeleteFAQS(int id)
        {

            var values = db.FAQs.Find(id);
            db.FAQs.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Banner Güncelleme
        [HttpGet]
        public ActionResult UpdateFAQS(int id)
        {
            var values = db.FAQs.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateFAQS(FAQ FAQ)
        {
            var values = db.FAQs.Find(FAQ.FAQId);
            values.FAQId = FAQ.FAQId;
            values.Question = FAQ.Question;
            values.Answer = FAQ.Answer;
            values.ImageUrl = FAQ.ImageUrl;
            values.Status = FAQ.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}