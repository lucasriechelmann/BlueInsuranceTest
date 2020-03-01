using BlueInsuranceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueInsuranceTest.Data.Mapping
{
    public class BaseMap
    {
        public void Configure<T>(EntityTypeBuilder<T> builder, string tableName) where T : BaseEntity
        {
            builder
                .ToTable(tableName);
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id");
            builder
                .Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired();
            builder
                .Property(x => x.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder
                .Property(x => x.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}
