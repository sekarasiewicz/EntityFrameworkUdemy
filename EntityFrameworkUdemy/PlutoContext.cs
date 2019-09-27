using EntityFrameworkUdemy.EntityConfigurations;
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
            
            modelBuilder.ApplyConfiguration(new CourseTagConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=CodeFirstDemo;User Id=sa;Password=Your_password123");
        }
    }
}