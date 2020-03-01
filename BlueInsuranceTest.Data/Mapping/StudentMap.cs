using BlueInsuranceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueInsuranceTest.Data.Mapping
{
    public class StudentMap : BaseMap, IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder, nameof(Student));

            builder
                .Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(x => x.Gender)
                .HasColumnName("Gender")
                .IsRequired();
            builder
                .Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .IsRequired();
            builder
                .Property(x => x.Address1)
                .HasColumnName("Address1")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(x => x.Address2)
                .HasColumnName("Address2")
                .HasMaxLength(100);
            builder
                .Property(x => x.Address3)
                .HasColumnName("Address3")
                .HasMaxLength(100);            
        }
    }
}
