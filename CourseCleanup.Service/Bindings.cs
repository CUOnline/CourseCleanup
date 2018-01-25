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
            Bind<IUnusedCourseStatusUpdateManager>().To<UnusedCourseStatusUpdateManager>();

            // BLL
            Bind<IUnusedCourseBLL>().To<UnusedCourseBLL>();
            Bind<ICourseSearchQueueBLL>().To<CourseSearchQueueBLL>();
            Bind<ISendEmailBLL>().To<SendEmailBLL>();
            

            // Repository
            Bind<IUnusedCourseRepository>().To<UnusedCourseRepository>();
            Bind<ICourseSearchQueueRepository>().To<CourseSearchQueueRepository>();
        }
    }
}
