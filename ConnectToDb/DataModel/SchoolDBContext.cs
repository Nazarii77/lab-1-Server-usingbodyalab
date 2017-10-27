namespace ConnectToDb.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;


    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("SchoolDB-DataAnnotations")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                        .HasMany<Course>(s => s.Courses)
                        .WithMany(c => c.Students)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });

        }
    }
}