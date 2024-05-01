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
    public class TeacherLoginController : Controller
    {
        //Öğretmen Giriş Sayfası


        LearnerContext db = new LearnerContext();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var values = db.Teachers.FirstOrDefault(x => x.UserName == teacher.UserName && x.Password == teacher.Password);//Veri tabındakiyle kulllanıcının girmiş olduğu bilgiler tutarlıysa 
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {   //çerez-->bilgilerin saklanılan yeri kullancıı adı veya sifreyi hafızada tutuyorda ubiste oldugu gibi.
                FormsAuthentication.SetAuthCookie(values.UserName, false);//kimlik doğrulama başarılı olursa cookie(çerez) yerletirir oturum acık olduğu sürece saklanır.false-->çerez kalıcı değidir
                Session["teacherName"] = values.NameSurname;//otorum boyunca öğretmenin adını ve soyadını tutacak.
                return RedirectToAction("Index", "TeacherCourse");//oturum dogru acılırsa teacherkursun indexine atacak
            }
        }
    }
     
}