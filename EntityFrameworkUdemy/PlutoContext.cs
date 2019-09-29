using EntityFrameworkUdemy.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUdemy
{
    public class PlutoContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new CourseTagConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false).UseSqlServer("Server=127.0.0.1;Database=CodeFirstDemo;User Id=sa;Password=Your_password123");
        }
    }
}