﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public String NameSurname { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}