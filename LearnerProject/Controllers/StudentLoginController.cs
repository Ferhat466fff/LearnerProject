using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class StudentLoginController : Controller
    {
        //1.Aşama-->Öğrenci Giriş Yapacak
        //2.Aşama-->CourseRegister Sayfasına Gidecek 


        LearnerContext db = new LearnerContext();

        //Öğrenci Giriş Yapacak
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student Student)
        {
            var values = db.Students.FirstOrDefault(x => x.UserName == Student.UserName && x.Password == Student.Password);//Veri tabındakiyle kulllanıcının girmiş olduğu bilgiler tutarlıysa 
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {   //çerez-->bilgilerin saklanılan yeri kullancıı adı veya sifreyi hafızada tutuyorda ubiste oldugu gibi.
                FormsAuthentication.SetAuthCookie(values.UserName, false);//kimlik doğrulama başarılı olursa cookie(çerez) yerletirir oturum acık olduğu sürece saklanır.false-->çerez kalıcı değidir
                Session["StudentName"] = values.NameSurname;//Oturum boyunca öğretmenin adını ve soyadını tutacak.
                return RedirectToAction("Index", "CourseRegister");//oturum dogru acılırsa teacherkursun indexine atacak
            }
        }
    }
}