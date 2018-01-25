using Canvas.Clients;
using CourseCleanup.Interface.BLL;
using CourseCleanup.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Service
{
    public class UnusedCourseStatusUpdateManager : IUnusedCourseStatusUpdateManager
    {
        private IUnusedCourseBLL unusedCourseBll;
        public UnusedCourseStatusUpdateManager(IUnusedCourseBLL unusedCourseBll)
        {
            this.unusedCourseBll = unusedCourseBll;
        }

        public void RunQueuedUpdates()
        {
            try
            {
                var coursesPendingDeletion = unusedCourseBll.GetAll().Where(x => x.Status == CourseStatus.PendingDeletion).ToList();

                if (coursesPendingDeletion.Any())
                {
                    var coursesClient = new CoursesClient();

                    foreach(var course in coursesPendingDeletion)
                    {
                        if (coursesClient.DeleteCourse(course.CourseId).Result)
                        {
                            course.Status = CourseStatus.Deleted;
                            unusedCourseBll.Update(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileLogger.Log("RunQueuedUpdates :: " + ex.ToString());
            }
        }
    }
}
