using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseCleanup.Models
{
    public class SearchQueueResultViewModel
    {
        public int CourseSearchQueueId { get; set; }

        public List<UnusedCourse> UnusedCourses { get; set; }
    }
}