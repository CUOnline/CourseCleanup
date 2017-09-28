using CourseCleanup.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseCleanup.Models;
using System.Data.Entity.Migrations;

namespace CourseCleanup.Repository
{
    public class DeletedCourseRepository : RepositoryBase, IDeletedCourseRepository
    {
        public DeletedCourse Add(DeletedCourse model)
        {
            Context.DeletedCourses.Add(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<DeletedCourse> AddAsync(DeletedCourse model)
        {
            Context.DeletedCourses.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public DeletedCourse Get(int modelId)
        {
            return Context.DeletedCourses.Find(modelId);
        }

        public IEnumerable<DeletedCourse> GetAll()
        {
            return Context.DeletedCourses;
        }

        public async Task<IEnumerable<DeletedCourse>> GetAllAsync()
        {
            return Context.DeletedCourses;
        }

        public async Task<DeletedCourse> GetAsync(int modelId)
        {
            return await Context.DeletedCourses.FindAsync(modelId);
        }

        public DeletedCourse Update(DeletedCourse model)
        {
            Context.DeletedCourses.AddOrUpdate(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<DeletedCourse> UpdateAsync(DeletedCourse model)
        {
            Context.DeletedCourses.AddOrUpdate(model);
            await Context.SaveChangesAsync();
            return model;
        }
    }
}
