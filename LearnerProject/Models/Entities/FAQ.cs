using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class FAQ
    {
        public int FAQId { get; set; }
        public String Question { get; set; }//soru
        public String Answer { get; set; }//cevap
        public String ImageUrl { get; set; }

        public bool Status { get; set; }//bool-->evet hayır
    }
}