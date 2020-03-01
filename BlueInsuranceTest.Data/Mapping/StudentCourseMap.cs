using BlueInsuranceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueInsuranceTest.Data.Mapping
{
    public class StudentCourseMap : BaseMap, IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            base.Configure(builder, nameof(StudentCourse));

            builder
                .HasIndex("CourseId", "StudentId")
                .IsUnique();
            builder
                .Property(x => x.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();
            builder
                .HasOne(x => x.Course)
                .WithMany();
            builder
                .Property(x => x.StudentId)
                .HasColumnName("StudentId")
                .IsRequired();
            builder
                .HasOne(x => x.Student)
                .WithMany();
        }
    }
}
