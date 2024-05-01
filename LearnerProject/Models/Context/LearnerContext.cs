using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LearnerProject.Models.Entities;

namespace LearnerProject.Models.Context
{
    public class LearnerContext :DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categoryies { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseVideo> CourseVideos { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<message> messages { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}