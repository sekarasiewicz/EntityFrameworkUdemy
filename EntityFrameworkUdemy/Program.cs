using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        }
    }
}