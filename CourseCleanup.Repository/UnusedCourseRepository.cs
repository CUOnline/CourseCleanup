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
    public class UnusedCourseRepository : RepositoryBase, IUnusedCourseRepository
    {
        public UnusedCourse Add(UnusedCourse model)
        {
            Context.UnusedCourses.Add(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<UnusedCourse> AddAsync(UnusedCourse model)
        {
            Context.UnusedCourses.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public UnusedCourse Get(int modelId)
        {
            return Context.UnusedCourses.Find(modelId);
        }

        public IEnumerable<UnusedCourse> GetAll()
        {
            return Context.UnusedCourses;
        }

        public async Task<IEnumerable<UnusedCourse>> GetAllAsync()
        {
            return Context.UnusedCourses;
        }

        public async Task<UnusedCourse> GetAsync(int modelId)
        {
            return await Context.UnusedCourses.FindAsync(modelId);
        }

        public UnusedCourse Update(UnusedCourse model)
        {
            Context.UnusedCourses.AddOrUpdate(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<UnusedCourse> UpdateAsync(UnusedCourse model)
        {
            Context.UnusedCourses.AddOrUpdate(model);
            await Context.SaveChangesAsync();
            return model;
        }
    }
}
