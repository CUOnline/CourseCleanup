using CourseCleanup.BLL;
using CourseCleanup.Interface.BLL;
using CourseCleanup.Interface.Repository;
using CourseCleanup.Repository;
using Ninject.Modules;
using System;

namespace CourseCleanup.Service
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnusedCourseSearchManager>().To<UnusedCourseSearchManager>();

            // BLL
            Bind<IUnusedCourseBLL>().To<UnusedCourseBLL>();
            Bind<ICourseSearchQueueBLL>().To<CourseSearchQueueBLL>();

            // Repository
            Bind<IUnusedCourseRepository>().To<UnusedCourseRepository>();
            Bind<ICourseSearchQueueRepository>().To<CourseSearchQueueRepository>();
        }
    }
}
