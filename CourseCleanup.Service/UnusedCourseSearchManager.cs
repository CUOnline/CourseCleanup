﻿using Canvas.Clients;
using Canvas.Clients.Models;
using CourseCleanup.Interface.BLL;
using CourseCleanup.Models;
using CourseCleanup.Models.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Service
{
    public class UnusedCourseSearchManager : IUnusedCourseSearchManager
    {
        private readonly ICourseSearchQueueBLL courseSearchQueueBll;
        private readonly IUnusedCourseBLL unusedCourseBll;
        private readonly ISendEmailBLL sendEmailBll;

        public UnusedCourseSearchManager(ICourseSearchQueueBLL courseSearchQueueBll, IUnusedCourseBLL unusedCourseBll, ISendEmailBLL sendEmailBll)
        {
            this.courseSearchQueueBll = courseSearchQueueBll;
            this.unusedCourseBll = unusedCourseBll;
            this.sendEmailBll = sendEmailBll;
        }

        public void RunQueuedSearchesAsync()
        {
            try
            {
                var search = courseSearchQueueBll.GetNextSearchToProcess();
                if (search != null)
                {
                    search.Status = SearchStatus.Pending;
                    courseSearchQueueBll.Update(search);

                    try
                    {
                        RunSearch(search.Id, search.StartTermId, search.EndTermId);
                    }
                    catch(Exception ex)
                    {
                        search.Status = SearchStatus.Failed;
                        search.StatusMessage = ex.Message;
                        courseSearchQueueBll.Update(search);
                    }

                    if (search.Status != SearchStatus.Failed)
                    {
                        search.Status = SearchStatus.Completed;
                        courseSearchQueueBll.Update(search);
                    }

                    Dictionary<string, string> subjectReplacements = new Dictionary<string, string>()
                    {
                        { "@Status", Enum.GetName(typeof(SearchStatus), search.Status) }
                    };

                    sendEmailBll.SendEmail(search.SubmittedByEmail, EmailTemplate.UnusedCourseSearch, new Dictionary<string, string>(), subjectReplacements);
                }
            }
            catch (Exception ex)
            {
                FileLogger.Log("RunQueuedSearchesAsync :: " + ex.ToString());
            }
        }

        private void RunSearch(int searchId, string startTermId, string endTermId)
        {
            var accountId = ConfigurationManager.AppSettings["CanvasAccountId"];
            var accountsClient = new AccountsClient();
            var enrollmentTerms = accountsClient.GetEnrollmentTerms(accountId).Result;
            
            // Start by getting all enrollment terms between range
            var subTerms = enrollmentTerms.SkipWhile(x => x.Id != startTermId.ToString()).TakeWhile(x => x.Id != endTermId.ToString()).ToList();
            subTerms.Add(enrollmentTerms.First(x => x.Id == endTermId.ToString()));

            foreach (var term in subTerms)
            {
                var courses = accountsClient.GetUnpublishedCoursesForTerm(accountId, term.Id).Result;

                foreach (var course in courses)
                {
                    if (IsUnusedCourse(course))
                    {
                        unusedCourseBll.Add(new UnusedCourse
                        {
                            CourseId = course.Id,
                            CourseCode = course.CourseCode,
                            CourseSISID = course.SisCourseId,
                            CourseName = course.Name,
                            Status = CourseStatus.Active,
                            TermId = term.Id,
                            Term = term.Name,
                            CourseSearchQueueId = searchId
                        });
                    }
                }
            }
        }

        /// <summary>
        /// A Course Shell is an unpublished course that has no content or activity
        /// </summary>
        private bool IsUnusedCourse(Course course)
        {
            var client = new CoursesClient();

            var courseWithSyllabus = client.GetWithSyllabusBody(course.Id).Result;
            if (!string.IsNullOrWhiteSpace(courseWithSyllabus.SyllabusBody))
            {
                return false;
            }

            var enrollments = client.GetEnrollments(course.Id).Result;
            if (enrollments.Any(x => x.LastActivityAt != null))
            {
                return false;
            }

            var assignments = client.GetCourseAssignments(course.Id).Result;
            if (assignments.Any())
            {
                return false;
            }

            var modules = client.GetCourseModules(course.Id).Result;
            if (modules.Any())
            {
                return false;
            }

            var files = client.GetCourseFiles(course.Id).Result;
            if (files.Any())
            {
                return false;
            }

            var pages = client.GetCoursePages(course.Id).Result;
            if (pages.Any())
            {
                return false;
            }

            var discussions = client.GetCourseDiscussions(course.Id).Result;
            if (discussions.Any())
            {
                return false;
            }

            var quizzes = client.GetCourseQuizzes(course.Id).Result;
            if (quizzes.Any())
            {
                return false;
            }

            return true;
        }
    }
}
