﻿using CourseCleanup.Interface.Repository;
using CourseCleanup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace CourseCleanup.Repository
{
    public class CourseSearchQueueRepository : RepositoryBase, ICourseSearchQueueRepository
    {
        public CourseSearchQueue Add(CourseSearchQueue model)
        {
            Context.CourseSearchQueues.Add(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<CourseSearchQueue> AddAsync(CourseSearchQueue model)
        {
            Context.CourseSearchQueues.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public CourseSearchQueue Get(int modelId)
        {
            return Context.CourseSearchQueues.Find(modelId);
        }

        public IEnumerable<CourseSearchQueue> GetAll()
        {
            return Context.CourseSearchQueues;
        }

        public async Task<IEnumerable<CourseSearchQueue>> GetAllAsync()
        {
            return Context.CourseSearchQueues;
        }

        public async Task<CourseSearchQueue> GetAsync(int modelId)
        {
            return await Context.CourseSearchQueues.FindAsync(modelId);
        }

        public CourseSearchQueue Update(CourseSearchQueue model)
        {
            Context.CourseSearchQueues.AddOrUpdate(model);
            Context.SaveChanges();
            return model;
        }

        public async Task<CourseSearchQueue> UpdateAsync(CourseSearchQueue model)
        {
            Context.CourseSearchQueues.AddOrUpdate(model);
            await Context.SaveChangesAsync();
            return model;
        }
    }
}
