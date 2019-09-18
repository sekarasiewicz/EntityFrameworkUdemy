using System.Collections.Generic;

namespace EntityFrameworkUdemy
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}