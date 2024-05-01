using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public String NameSurname { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public List<Course>Courses { get; set; }
    }
}