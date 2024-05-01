using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Testimonial//Referanslarım
    {
        public int TestimonialId { get; set; }
        public String NameSurname { get; set; }
        public String Title { get; set; }
        public String ImageUrl { get; set; }
        public String Comment { get; set; }
    }
}