using CourseCleanup.Models.Enums;

namespace CourseCleanup.Models
{
    public class CourseSearchQueue : ModelBase
    {
        public string StartTermId { get; set; }
        public string EndTermId { get; set; }
        public SearchStatus Status { get; set; }
        public string StatusMessage { get; set; }
        public string SubmittedByEmail { get; set; }
    }
}
