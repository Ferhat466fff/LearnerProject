﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class CourseRegister
    {
        public int CourseRegisterId { get; set; }

        
        public int StudentId { get; set; }//öğrenci ile ilşki
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }//kurs ile ilşki
        public virtual Course Course { get; set; }

    }
}