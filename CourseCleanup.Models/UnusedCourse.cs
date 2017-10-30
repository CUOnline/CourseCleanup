using CourseCleanup.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Models
{
    public class UnusedCourse : ModelBase
    {
        public DateTime ReportGeneratedDate { get; set; }
        public string CourseName { get; set; }
        public string CourseSISID { get; set; }
        public string CourseCode { get; set; }
        public string Term { get; set; }
        public CourseStatus Status { get; set; }
    }
}
