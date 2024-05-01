using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Adress { get; set; }
        public string OpenHaurs { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}