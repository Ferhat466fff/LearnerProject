using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Student//öğrenci tablosu
    {
        public int StudentId { get; set; }
        public  String NameSurname { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }


        //ilişki review(değerlendirme)
        public List<Review>Review { get; set; }
        //Kurs Kayıt ile ilişki
        public List<CourseRegister> CourseRegister { get; set; }
    }
}