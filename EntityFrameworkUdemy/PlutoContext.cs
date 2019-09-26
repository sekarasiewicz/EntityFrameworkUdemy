using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUdemy
{
    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

//        protected PlutoContext() : base("name=DefaultConnection")
//                 {
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTag>()
                .HasKey(ct => new { ct.CourseId, ct.TagId });

            modelBuilder.Entity<CourseTag>()
                .HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTags)
                .HasForeignKey(ct => ct.CourseId);

            modelBuilder.Entity<CourseTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.CourseTags)
                .HasForeignKey(ct => ct.TagId);

            modelBuilder.Entity<Course>().
                Property(c => c.Description).
                HasDefaultValue("Default");

            modelBuilder.Entity<Course>().Property(c => c.Title).IsRequired();

            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsRequired().HasMaxLength(2000);
            modelBuilder.
                Entity<Course>().
                HasOne(c => c.Author).
                WithMany(a => a.Courses).
                HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=CodeFirstDemo;User Id=sa;Password=Your_password123");
        }
    }
}