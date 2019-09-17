using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUdemy
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
//        public ICollection<Tag> Tags { get; set; }
        public List<CourseTag> CourseTags { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
//        public ICollection<Course> Courses{ get; set; }
        public List<CourseTag> CourseTags { get; set; }
    }
    
    public class CourseTag
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

//        protected PlutoContext() : base("name=DefaultConnection")
//                 {
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTag>()
                .HasKey(pt => new { pt.CourseId, pt.TagId });

            modelBuilder.Entity<CourseTag>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseTags)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.CourseTags)
                .HasForeignKey(pt => pt.TagId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=CodeFirstDemo;User Id=sa;Password=Your_password123");
        }
    }
    // TODO: Check design if it is really needed
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}