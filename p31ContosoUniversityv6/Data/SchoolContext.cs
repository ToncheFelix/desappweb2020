using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity.Data
{
    public class SchoolContext:  IdentityDbContext<User>
    {
         public SchoolContext(DbContextOptions<SchoolContext> options) 
         : base(options)
         {

         }
         public DbSet<Course> Courses{ get; set;}
         public DbSet<Enrollment> Enrollments{ get; set;}
         public DbSet<Student> Students{ get; set;}
         public DbSet<Department> Departments{ get; set;}
         public DbSet<Instructor> Instructors{ get; set;}
         public DbSet<OfficeAssignment> OfficeAssignments{ get; set;}
         public DbSet<CourseAssignment> CourseAssignments{ get; set;}

        //Api fluida
        protected override void OnModelCreating (ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssignment>().HasKey(c=> new {c.CourseID, c.InstructorID});
        }
       

    }

}