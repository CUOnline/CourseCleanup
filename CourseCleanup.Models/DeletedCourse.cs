using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Models
{
    public class DeletedCourse : ModelBase
    {
        public string CourseName { get; set; }
        public string CourseSISID { get; set; }
        public string CourseCode { get; set; }
        public string Term { get; set; }
        public string Status { get; set; }
    }
}
