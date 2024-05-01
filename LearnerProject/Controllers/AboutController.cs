using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AboutController : Controller
    {
        LearnerContext db = new LearnerContext();

        //Hakkımda Listeleme
        public ActionResult Indexx()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }

        //Hakkımda Ekleme
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About k)
        {
            db.Abouts.Add(k);
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }

        //Hakkımda Silme
        public ActionResult DeleteAbout(int id)
        {
            var values = db.Abouts.Find(id);
            db.Abouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }


        //Hakkımda Güncelleme
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.Abouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About k)
        {
            var values = db.Abouts.Find(k.AboutId);
            values.AboutId = k.AboutId;
            values.Title = k.Title;
            values.Description = k.Description;
            values.ImageUrl = k.ImageUrl;
            values.Item1 = k.Item1;
            values.Item2 = k.Item2;
            values.Item3 = k.Item3;
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }




    }
}