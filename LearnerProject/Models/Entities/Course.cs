using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Course//kurs
    {
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }



        //İlişkiler

        //Her kursun bir kategorisi olacak ve her kursun bir ogretmeni olacak
        public int CategoryId { get; set; }//ilişki kurduk
        public virtual Category Category { get; set; }//kategori sınıfından category adında nesne oluşturup içindeki değerlere ulaşmak istiyoruz.


        //Her Kursun Bir Öğretmeni Olacak
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        //Değerlendirme ile ilişki
        public List<Review> Reviewes { get; set; }

        //Kurs Kayıt İle İlişki
        public List<CourseRegister> CourseRegister { get; set; }

        //Kurs Video İle İlişkili
        public List<CourseVideo> CourseVideo { get; set; }

    }
}