﻿using efcoreApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }


    }
}
