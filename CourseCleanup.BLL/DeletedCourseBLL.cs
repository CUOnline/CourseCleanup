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
    public class DeletedCourseBLL : IDeletedCourseBLL
    {
        private readonly IDeletedCourseRepository deletedCourseRepository;

        public DeletedCourseBLL(IDeletedCourseRepository deletedCourseRepository)
        {
            this.deletedCourseRepository = deletedCourseRepository;
        }

        public DeletedCourse Add(DeletedCourse model)
        {
            model.DateCreated = DateTime.Now;
            return deletedCourseRepository.Add(model);
        }

        public async Task<DeletedCourse> AddAsync(DeletedCourse model)
        {
            model.DateCreated = DateTime.Now;
            return await deletedCourseRepository.AddAsync(model);
        }

        public DeletedCourse Get(int modelId)
        {
            return deletedCourseRepository.Get(modelId);
        }

        public IEnumerable<DeletedCourse> GetAll()
        {
            return deletedCourseRepository.GetAll();
        }

        public async Task<IEnumerable<DeletedCourse>> GetAllAsync()
        {
            return await deletedCourseRepository.GetAllAsync();
        }

        public async Task<DeletedCourse> GetAsync(int modelId)
        {
            return await deletedCourseRepository.GetAsync(modelId);
        }

        public DeletedCourse Update(DeletedCourse model)
        {
            model.LastUpdated = DateTime.Now;
            return deletedCourseRepository.Update(model);
        }

        public async Task<DeletedCourse> UpdateAsync(DeletedCourse model)
        {
            model.LastUpdated = DateTime.Now;
            return await deletedCourseRepository.UpdateAsync(model);
        }
    }
}
