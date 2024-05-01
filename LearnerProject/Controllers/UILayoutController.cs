using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LearnerProject.Models.Context;

namespace LearnerProject.Controllers
{
    public class UILayoutController : Controller
    {
        LearnerContext db = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
     

        
    }
}