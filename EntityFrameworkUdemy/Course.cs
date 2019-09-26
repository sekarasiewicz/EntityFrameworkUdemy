using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUdemy
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        [Required] public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }

        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }

//        public ICollection<Tag> Tags { get; set; }
        public List<CourseTag> CourseTags { get; set; }

        public Category Category { get; set; }
        
        public Cover Cover { get; set; }
    }
}