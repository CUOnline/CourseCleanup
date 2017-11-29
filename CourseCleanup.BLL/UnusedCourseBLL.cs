using CourseCleanup.Interface.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseCleanup.Models;
using CourseCleanup.Interface.Repository;

namespace CourseCleanup.BLL
{
    public class UnusedCourseBLL : IUnusedCourseBLL
    {
        private readonly IUnusedCourseRepository unusedCourseRepository;

        public UnusedCourseBLL(IUnusedCourseRepository unusedCourseRepository)
        {
            this.unusedCourseRepository = unusedCourseRepository;
        }

        public UnusedCourse Add(UnusedCourse model)
        {
            model.DateCreated = DateTime.Now;
            return unusedCourseRepository.Add(model);
        }

        public async Task<UnusedCourse> AddAsync(UnusedCourse model)
        {
            model.DateCreated = DateTime.Now;
            return await unusedCourseRepository.AddAsync(model);
        }

        public UnusedCourse Get(int modelId)
        {
            return unusedCourseRepository.Get(modelId);
        }

        public IEnumerable<UnusedCourse> GetAll()
        {
            return unusedCourseRepository.GetAll();
        }

        public async Task<IEnumerable<UnusedCourse>> GetAllAsync()
        {
            return await unusedCourseRepository.GetAllAsync();
        }

        public async Task<UnusedCourse> GetAsync(int modelId)
        {
            return await unusedCourseRepository.GetAsync(modelId);
        }

        public UnusedCourse Update(UnusedCourse model)
        {
            model.LastUpdated = DateTime.Now;
            return unusedCourseRepository.Update(model);
        }

        public async Task<UnusedCourse> UpdateAsync(UnusedCourse model)
        {
            model.LastUpdated = DateTime.Now;
            return await unusedCourseRepository.UpdateAsync(model);
        }
    }
}
