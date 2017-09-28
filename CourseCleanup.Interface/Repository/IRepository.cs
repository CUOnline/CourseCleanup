using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseCleanup.Interface.Repository
{
    public interface IRepository<T>
    {
        T Add(T model);
        Task<T> AddAsync(T model);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int modelId);
        Task<T> GetAsync(int modelId);
        T Update(T model);
        Task<T> UpdateAsync(T model);
    }
}