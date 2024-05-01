using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class ReviewController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();



        //Review(Değerlednirme Puanları)
        public ActionResult Index()
        {
            var values = db.Reviews.ToList();
            return View(values);
        }

        //Review Silme 
        public ActionResult DeleteReview(int id)
        {

            var values = db.Reviews.Find(id);
            db.Reviews.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}