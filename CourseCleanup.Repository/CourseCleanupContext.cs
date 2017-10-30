using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CourseCleanup.Models;
using CourseCleanup.Repository.Maps;

namespace CourseCleanup.Repository
{
    public class CourseCleanupContext : DbContext
    {
        public CourseCleanupContext() : base("CourseCleanupContext") { }

        public DbSet<UnusedCourse> UnusedCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("DateTime2"));

            modelBuilder.Configurations.Add(new UnusedCourseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
