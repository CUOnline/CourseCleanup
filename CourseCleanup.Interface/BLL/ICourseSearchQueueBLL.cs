using CourseCleanup.Models;
using System.Threading.Tasks;

namespace CourseCleanup.Interface.BLL
{
    public interface ICourseSearchQueueBLL : IBLL<CourseSearchQueue>
    {
        CourseSearchQueue GetNextSearchToProcess();
    }
}
