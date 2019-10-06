using System.Collections.Generic;

namespace EntityFrameworkUdemy.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int course);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}