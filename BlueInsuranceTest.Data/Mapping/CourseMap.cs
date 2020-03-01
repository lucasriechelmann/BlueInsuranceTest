using BlueInsuranceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueInsuranceTest.Data.Mapping
{
    public class CourseMap : BaseMap, IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder, nameof(Course));

            builder
                .Property(x => x.Code)
                .HasColumnName("Code")
                .HasMaxLength(10)
                .IsRequired();
            builder
                .HasIndex(x => x.Code)
                .IsUnique();
            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(x => x.TeacherName)
                .HasColumnName("TeacherName")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();
            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .IsRequired();
            builder
                .Property(x => x.StudentLimit)
                .HasColumnName("StudentLimit")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}
