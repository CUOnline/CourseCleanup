using System;

namespace CourseCleanup.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}