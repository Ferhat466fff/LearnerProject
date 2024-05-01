using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class ContactController : Controller
    {
        LearnerContext db = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactInfo()
        {
            var values = db.Contacts.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(message message)
        {
            message.IsRead = false;
            db.messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}