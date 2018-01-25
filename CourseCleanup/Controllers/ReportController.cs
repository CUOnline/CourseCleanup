using CourseCleanup.Interface.BLL;
using CourseCleanup.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CourseCleanup.Controllers
{
    public class ReportController : Controller
    {
        private readonly ICourseSearchQueueBLL courseSearchQueueBll;
        private readonly IUnusedCourseBLL unusedCourseBll;

        public ReportController(ICourseSearchQueueBLL courseSearchQueueBll, IUnusedCourseBLL unusedCourseBll)
        {
            this.courseSearchQueueBll = courseSearchQueueBll;
            this.unusedCourseBll = unusedCourseBll;
        }

        public async Task<ActionResult> DeletedCoursesReport()
        {
            var deletedCourses = unusedCourseBll.GetAll().Where(x => x.Status == Models.Enums.CourseStatus.Deleted);

            var model = new SearchQueueResultViewModel()
            {
                UnusedCourses = deletedCourses.ToList()
            };

            return View(model);
        }

        public async Task<ActionResult> Index(int courseSearchQueueId)
        {
            var unusedCourses = unusedCourseBll.GetAll().Where(x => x.CourseSearchQueueId == courseSearchQueueId);

            var model = new SearchQueueResultViewModel()
            {
                CourseSearchQueueId = courseSearchQueueId,
                UnusedCourses = unusedCourses.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchQueueResultViewModel viewModel)
        {
            var unusedCourses = unusedCourseBll.GetAll().Where(x => x.CourseSearchQueueId == viewModel.CourseSearchQueueId).ToList();

            foreach (var course in unusedCourses)
            {
                course.Status = Models.Enums.CourseStatus.PendingDeletion;
                unusedCourseBll.Update(course);
            }

            viewModel.UnusedCourses = unusedCourses;

            return View(viewModel);
        }
    }
}