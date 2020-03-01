using BlueInsuranceTest.Data.Mapping;
using BlueInsuranceTest.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueInsuranceTest.Data.Context
{
    public class BlueInsuranceTestContext : IdentityDbContext<User>
    {
        public BlueInsuranceTestContext(DbContextOptions<BlueInsuranceTestContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>(new StudentMap().Configure);
            builder.Entity<Course>(new CourseMap().Configure);
            builder.Entity<StudentCourse>(new StudentCourseMap().Configure);
        }
    }
}
