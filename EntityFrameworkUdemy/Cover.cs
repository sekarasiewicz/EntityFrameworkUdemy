﻿namespace EntityFrameworkUdemy
{
    public class Cover
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}