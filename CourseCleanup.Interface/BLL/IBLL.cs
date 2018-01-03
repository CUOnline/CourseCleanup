using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseCleanup.Interface.BLL
{
    public interface IBLL<T>
    {
        T Add(T model);
        Task<T> AddAsync(T model);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int modelId);
        Task<T> GetAsync(int modelId);
        T Update(T model);
    }
}