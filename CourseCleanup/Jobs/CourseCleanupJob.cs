using CUHangFire.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CourseCleanup.Jobs
{
    public class CourseCleanupJob : ICourseCleanupJob
    {
        public async Task Execute(int startTermId, int endTermId, string userEmail)
        {

        }
    }
}