using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class MessageController : Controller
    {//Admin Kısmı

        LearnerContext db = new LearnerContext();



        //Gelen Mesajları Listeleme
        public ActionResult Index()
        {
            var values = db.messages.ToList();
            return View(values);
        }

        //Okunmadı
        public ActionResult IsNotRead(int id) 
        {
            var item = db.messages.Find(id);

            item.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Okundu
        public ActionResult IsRead(int id) 
        {
            var item = db.messages.Find(id);

            item.IsRead = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSendMessage(int id)
        {
            var value = db.messages.Find(id);
            db.messages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult MessageDetail(int id)
        {
            var value = db.messages.Find(id);
            return View(value);
        }


    }
}