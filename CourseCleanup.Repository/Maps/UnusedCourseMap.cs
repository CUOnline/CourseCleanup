using CourseCleanup.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Repository.Maps
{
    public class UnusedCourseMap : EntityTypeConfiguration<UnusedCourse>
    {
        public UnusedCourseMap()
        {

        }
    }
}
