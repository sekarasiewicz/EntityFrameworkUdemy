using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUdemy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            // LINQ syntax
            var query = from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }

            // Extension methods
            var courses = context.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                Console.WriteLine("COURSE - {0}", course.Name);
            }

            var queryable = context.Courses.Join(context.Authors, c => c.AuthorId, a => a.Id, (course, author) => new
            {
                CourseName = course.Name,
                AuthorName = author.Name
            });

            foreach (var q in queryable)
            {
                Console.WriteLine(q);
            }

            // Partitioning
            context.Courses.Skip(10).Take(10);

            // Element operators
            context.Courses.First();
            context.Courses.FirstOrDefault(c => c.FullPrice > 100);
            context.Courses.OrderBy(c => c.Level).Last(c => c.FullPrice > 100);
            context.Courses.SingleOrDefault(c => c.Id == 1);

            // Quantifying
            var all = context.Courses.All(c => c.FullPrice > 10);
            var any = context.Courses.Any(c => c.FullPrice > 10);

            // Aggregating
            context.Courses.Count();
            context.Courses.Average(c => c.FullPrice);
            context.Courses.Sum(c => c.FullPrice);
            context.Courses.Min(c => c.FullPrice);
            context.Courses.Max(c => c.FullPrice);

            // IQueryable
            IQueryable<Course> courses2 = context.Courses;
            var filtered = courses2.Where(c => c.Level == (CourseLevel) 1);
            foreach (var course in filtered)
            {
                Console.WriteLine(course);
            }

            IEnumerable<Course> x = context.Courses;
            x.Where(c => c.Level == (CourseLevel) 1).OrderBy(c => c.Name);

            // Lazy loading problem n + 1 issue
//            var course3 = context.Courses.ToList();
//            foreach (var c in course3)
//            {
//                Console.WriteLine("{0}, by {1}", c.Name, c.Author.Name);
//            }

            // Eager loading
            var course4 = context.Courses.Include(c => c.Author).ToList();
            foreach (var c in course4)
            {
                Console.WriteLine("{0}, by {1}", c.Name, c.Author.Name);
            }

            // Explicit loading
            var author = context.Authors.Single(a => a.Id == 1);

            // MSDN way
            context.Entry(author).Collection(a => a.Courses).Load();

            // Mosh way
            context.Courses.Where(c => c.AuthorId == author.Id).Load();

            foreach (var c in author.Courses)
            {
                Console.WriteLine("{0}", c.Name);
            }

            var authors2 = context.Authors.ToList();
            var ids = authors2.Select(a => a.Id);

            context.Courses.Where(c => ids.Contains(c.AuthorId) && c.FullPrice == 0).Load();

            // Insert Actions
            AddCourse();
        }

        private static void AddCourse()
        {
            var context = new PlutoContext();
            var author = context.Authors.Single(a => a.Id == 1);

            var course = new Course
            {
                Name = "New Course 2",
                Title = "Some Title 2",
                Description = "New Description 2",
                FullPrice = 19.95f,
                Level = CourseLevel.Beginner,
                Author = author
            };

            context.Courses.Add(course);
            context.SaveChanges();
        }

        private static void Update()
        {
            var context = new PlutoContext();
            var course = context.Courses.Find(4);
            course.Name = "New Name";
            course.AuthorId = 2;

            context.SaveChanges();
        }

        private static void Delete()
        {
            var context = new PlutoContext();
            var course = context.Courses.Find(6);
            context.Courses.Remove(course);

            context.SaveChanges();
        }

        private static void DeleteMany()
        {
            var context = new PlutoContext();

            var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);
            context.Courses.RemoveRange(author.Courses);
            context.Authors.Remove(author);

            context.SaveChanges();
        }

        private static void ChangeTracker()
        {
            var context = new PlutoContext();
            context.Authors.Add(new Author {Name = "New Author"});
            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                Console.WriteLine(entry.State);
            }
        }
    }
}