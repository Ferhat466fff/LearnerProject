using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        LearnerContext Db = new LearnerContext();

        //Kategori Listeleme(Statüsü true olanları)
        public ActionResult Index()
        {
            var values = Db.Categoryies.Where(x=>x.Status==true).ToList();
            return View(values);
        }

        //Kategoriyi Pasife Alma(Silme gibi sadece biz görmüyoruz veritTabnında mevcut)
        public ActionResult DeleteCategory(int id)
        {
           var value= Db.Categoryies.Find(id);
           value.Status = false;//Silmdik false çektik farkettiysen
           Db.SaveChanges();
           return RedirectToAction("Index");
        }


        //Kategori Ekleme
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category Category)
        {
            Category.Status = true;//Durumu True Olarak Eklensin
            Db.Categoryies.Add(Category);
            Db.SaveChanges();
            return RedirectToAction("Index");

        }




        //Kategori Bilgilerini Getirme ve Güncelleme
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = Db.Categoryies.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category Category)
        {

            var value = Db.Categoryies.Find(Category.CategoryId);//Db.Categoryies-->Veritabanındaki Categori Tablomuzun ismi.
            value.CategoryName = Category.CategoryName;//Category Category-->Bizim Entities İçersisindeki Sınfımızın İsmi.
            value.Icon = Category.Icon;
            value.Status = true;
            Db.SaveChanges();
            return RedirectToAction("Index");

        }












    }
}