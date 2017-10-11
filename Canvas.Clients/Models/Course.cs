using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class Course : BaseModel
    {
        [JsonProperty(PropertyName = "syllabus_body")]
        public string SyllabusBody { get; set; }

        [JsonProperty(PropertyName = "sis_course_id")]
        public string SisCourseId { get; set; }

        [JsonProperty(PropertyName = "course_code")]
        public string CourseCode { get; set; }

        [JsonProperty(PropertyName = "enrollment_term_id")]
        public string EnrollmentTermId { get; set; }
    }
}
