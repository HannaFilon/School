using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using System;

namespace School.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
         : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseStudent>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

    }
}
