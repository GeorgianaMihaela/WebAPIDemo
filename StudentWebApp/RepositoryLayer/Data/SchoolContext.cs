using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentWebApp.RepositoryLayer.Models;

namespace StudentWebApp.RepositoryLayer.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public Student CreateStudent(Student student)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Student> entityEntry = Students.Add(student);
            this.SaveChanges();
            return entityEntry.Entity;
        }

        public Student UpdateStudent(Student student)
        {
            // Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Student> entityEntry =  Students.Add(student);
            this.Entry(student).CurrentValues.SetValues(student); 
            this.Entry(student).State = EntityState.Modified;
            this.SaveChanges();
            return this.Entry(student).Entity;
        }

        public List<Student> GetAllStudents()
        {
            return Students.ToList();
        }

       
    }
}
