using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class About//Hakkımda
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        public String Item1 { get; set; }
        public String Item2 { get; set; }
        public String Item3 { get; set; }

    }
}