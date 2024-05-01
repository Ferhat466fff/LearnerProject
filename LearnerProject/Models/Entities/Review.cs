using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Review//Değerlendirme
    {
        public int ReviewId { get; set; }


        //Kurs ile ilişki
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }


        public Double ReviewValue { get; set; }//öğrencinin vereceği puan
        public String Comment { get; set; }//yorum


        //öğrenciler(student) ilişki değerlendirme yapacak 
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }




    }
}