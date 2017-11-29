using CourseCleanup.Interface.BLL;
using CourseCleanup.Interface.Repository;
using CourseCleanup.Models;
using CourseCleanup.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.BLL
{
    public class CourseSearchQueueBLL : ICourseSearchQueueBLL
    {
        private readonly ICourseSearchQueueRepository courseSearchQueueRepository;

        public CourseSearchQueueBLL(ICourseSearchQueueRepository courseSearchQueueRepository)
        {
            this.courseSearchQueueRepository = courseSearchQueueRepository;
        }

        public CourseSearchQueue Add(CourseSearchQueue model)
        {
            model.DateCreated = DateTime.Now;
            return courseSearchQueueRepository.Add(model);
        }

        public async Task<CourseSearchQueue> AddAsync(CourseSearchQueue model)
        {
            model.DateCreated = DateTime.Now;
            return await courseSearchQueueRepository.AddAsync(model);
        }

        public CourseSearchQueue Get(int modelId)
        {
            return courseSearchQueueRepository.Get(modelId);
        }

        public IEnumerable<CourseSearchQueue> GetAll()
        {
            return courseSearchQueueRepository.GetAll();
        }

        public async Task<IEnumerable<CourseSearchQueue>> GetAllAsync()
        {
            return await courseSearchQueueRepository.GetAllAsync();
        }

        public async Task<CourseSearchQueue> GetAsync(int modelId)
        {
            return await courseSearchQueueRepository.GetAsync(modelId);
        }

        public async Task<CourseSearchQueue> GetNextSearchToProcess()
        {
            return (await courseSearchQueueRepository.GetAllAsync()).Where(x => x.Status == SearchStatus.New).OrderBy(x => x.DateCreated).FirstOrDefault();
        }

        public CourseSearchQueue Update(CourseSearchQueue model)
        {
            model.LastUpdated = DateTime.Now;
            return courseSearchQueueRepository.Update(model);
        }

        public async Task<CourseSearchQueue> UpdateAsync(CourseSearchQueue model)
        {
            model.LastUpdated = DateTime.Now;
            return await courseSearchQueueRepository.UpdateAsync(model);
        }
    }
}
