using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkUdemy.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
       
            builder.Property(c => c.Description).
                HasDefaultValue("Default");

            builder.Property(c => c.Title).IsRequired();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(2500);
            builder.
                HasOne(c => c.Author).
                WithMany(a => a.Courses).
                HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.NoAction);

            builder.
                HasOne(c => c.Cover).
                WithOne(c => c.Course).HasForeignKey<Cover>(c => c.CourseId);
        }
    }
}