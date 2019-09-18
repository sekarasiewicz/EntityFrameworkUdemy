using System.Collections.Generic;

namespace EntityFrameworkUdemy
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
//        public ICollection<Course> Courses{ get; set; }
        public List<CourseTag> CourseTags { get; set; }
    }
}