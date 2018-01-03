using System.Threading.Tasks;

namespace CourseCleanup.Service
{
    public interface IUnusedCourseSearchManager
    {
        void RunQueuedSearchesAsync();
    }
}