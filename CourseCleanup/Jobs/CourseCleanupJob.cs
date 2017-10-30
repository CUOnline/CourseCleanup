using Canvas.Clients;
using Canvas.Clients.Models;
using CourseCleanup.Interface.BLL;
using CourseCleanup.Models;
using CUHangFire.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CourseCleanup.Jobs
{
    public class CourseCleanupJob : ICourseCleanupJob
    {
        private readonly IUnusedCourseBLL unusedCourseBll;

        public CourseCleanupJob(IUnusedCourseBLL unusedCourseBll)
        {
            this.unusedCourseBll = unusedCourseBll;
        }

        public async Task Execute(int startTermId, int endTermId, string userEmail)
        {
            var accountId = ConfigurationManager.AppSettings["CanvasAccountId"];
            var accountsClient = new AccountsClient();
            var enrollmentTerms = await accountsClient.GetEnrollmentTerms(accountId);


            // Start by getting all enrollment terms between range
            var subTerms = enrollmentTerms.SkipWhile(x => x.Id != startTermId.ToString()).TakeWhile(x => x.Id != endTermId.ToString()).ToList();
            subTerms.Add(enrollmentTerms.First(x => x.Id == endTermId.ToString()));

            // foreach enrollment term, get all unpublished courses, checking for unused courses
            //var unusedCourses = new List<Course>();
            DataTable unUsedCourses = new DataTable("UnUsedCourses");
            unUsedCourses.Columns.Add(new DataColumn(nameof(Course.Id)));
            unUsedCourses.Columns.Add(new DataColumn(nameof(Course.Name)));
            unUsedCourses.Columns.Add(new DataColumn("EnrollmentTerm"));
            unUsedCourses.Columns.Add(new DataColumn(nameof(Course.CourseCode)));
            unUsedCourses.Columns.Add(new DataColumn(nameof(Course.SisCourseId)));

            var reportGeneratedDate = DateTime.Now;

            foreach (var term in subTerms)
            {
                var courses = await accountsClient.GetUnpublishedCoursesForTerm(accountId, term.Id);

                foreach(var course in courses)
                {
                    if (await IsUnusedCourse(course))
                    {
                        unusedCourseBll.Add(new UnusedCourse
                        {
                            CourseCode = course.CourseCode,
                            CourseSISID = course.SisCourseId,
                            CourseName = course.Name,
                            ReportGeneratedDate = reportGeneratedDate,
                            Status = Models.Enums.CourseStatus.Active,
                            Term = term.Id
                        });
                    }
                }
            }
            

            unUsedCourses.WriteXml(@"C:\Temp\UnusedCourses.xml");

            // Build a csv of the course shells to be emailed
            // email it.
        }

        /// <summary>
        /// A Course Shell is an unpublished course that has no content or activity
        /// </summary>
        private async Task<bool> IsUnusedCourse(Course course)
        {
            var client = new CoursesClient();
            
            var courseWithSyllabus = await client.GetWithSyllabusBody(course.Id);
            if(!string.IsNullOrWhiteSpace(courseWithSyllabus.SyllabusBody))
            {
                return false;
            }

            var enrollments = await client.GetEnrollments(course.Id);
            if(enrollments.Any(x => x.LastActivityAt != null))
            {
                return false;
            }

            var assignments = await client.GetCourseAssignments(course.Id);
            if (assignments.Any())
            {
                return false;
            }

            var modules = await client.GetCourseModules(course.Id);
            if (modules.Any())
            {
                return false;
            }
            
            var files = await client.GetCourseFiles(course.Id);
            if (files.Any())
            {
                return false;
            }

            var pages = await client.GetCoursePages(course.Id);
            if (pages.Any())
            {
                return false;
            }

            var discussions = await client.GetCourseDiscussions(course.Id);
            if (discussions.Any())
            {
                return false;
            }

            var quizzes = await client.GetCourseQuizzes(course.Id);
            if (quizzes.Any())
            {
                return false;
            }

            // Check for activity

            return true;
        }
    }
}