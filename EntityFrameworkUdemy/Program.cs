﻿using System;
using System.Linq;

namespace EntityFrameworkUdemy
{
    // TODO: Check design if it is really needed
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
        }
    }
}