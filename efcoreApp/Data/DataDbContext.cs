using efcoreApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CourseRegistration> CourseRegistrations => Set<CourseRegistration>();
        public DbSet<Teacher> Teachers => Set<Teacher>();


    }
}
