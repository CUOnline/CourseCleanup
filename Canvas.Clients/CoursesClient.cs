using Canvas.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients
{
    public class CoursesClient : ClientBase
    {
        public CoursesClient() : base($"courses") { }

        public async Task<Course> GetWithSyllabusBody(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}?include[]=syllabus_body";
            return await ExecuteGet<Course>(ApiPath);
        }

        public async Task<List<Assignment>> GetCourseAssignments(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/assignments";
            return await ExecuteGetAll<Assignment>(ApiPath);
        }

        public async Task<List<Module>> GetCourseModules(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/modules";
            return await ExecuteGetAll<Module>(ApiPath);
        }

        public async Task<List<File>> GetCourseFiles(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/files";
            return await ExecuteGetAll<File>(ApiPath);
        }

        public async Task<List<Page>> GetCoursePages(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/pages";
            return await ExecuteGetAll<Page>(ApiPath);
        }

        public async Task<List<Discussion>> GetCourseDiscussions(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/discussion_topics";
            return await ExecuteGetAll<Discussion>(ApiPath);
        }

        public async Task<List<Quiz>> GetCourseQuizzes(string courseId)
        {
            ApiPath = ApiController + $@"/{courseId}/quizzes";
            return await ExecuteGetAll<Quiz>(ApiPath);
        }

        //quizzes,
        ///api/v1/courses/:course_id/quizzes
    }
}
