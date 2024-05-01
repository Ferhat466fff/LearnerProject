using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class BannerController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();



        //Banner(Listeleme)
        public ActionResult Index()
        {
            var values = db.Banners.ToList();
            return View(values);
        }
        //Banner Ekleme
        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            db.Banners.Add(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Banner Silme
        public ActionResult DeleteBanner(int id)
        {

            var values = db.Banners.Find(id);
            db.Banners.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Banner Güncelleme
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var values = db.Banners.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var values = db.Banners.Find(banner.BannerId);
            values.BannerId = banner.BannerId;
            values.Title = banner.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}