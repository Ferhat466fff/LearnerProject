using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Category//kategori
    {
        //kategori Sınfı(sql tablo kısmı)
        public int CategoryId { get; set; }//prop yaz 2 kere tab bas
        public String CategoryName { get; set; }
        public String Icon { get; set; }
        public bool Status { get; set; }


        public List<Course>Courses { get; set; }//course ilişki kurduk ve listeledik.



    }
}