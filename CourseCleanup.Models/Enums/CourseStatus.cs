using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Models.Enums
{
    public enum CourseStatus
    {
        Active = 1,
        PendingDeletion = 2,
        Deleted = 3,
        PendingReactivation = 4
    }
}
