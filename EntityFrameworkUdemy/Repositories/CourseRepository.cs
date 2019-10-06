using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUdemy.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(PlutoContext context) : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int course)
        {
            return PlutoContext.Courses.OrderByDescending(c => c.FullPrice).Take(course).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return PlutoContext.Courses.Include(c => c.Author).OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private PlutoContext PlutoContext => Context as PlutoContext;
    }
}