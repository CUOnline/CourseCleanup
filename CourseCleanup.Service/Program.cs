using CourseCleanup.Interface.BLL;
using Ninject;
using System;
using System.ServiceProcess;

namespace CourseCleanup.Service
{
    class Program
    {
        static void Main()
        {
            try
            {
                IKernel kernel = new StandardKernel(new Bindings());
                
                var unusedCourseBll = kernel.Get<IUnusedCourseBLL>();
                var unusedCourseSearchManager = kernel.Get<IUnusedCourseSearchManager>();
                var unusedCourseStatusUpdateManager = kernel.Get<IUnusedCourseStatusUpdateManager>();

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new CUOUnusedCourseSearch(unusedCourseSearchManager),
                    new CUOUnusedCourseDelete(unusedCourseStatusUpdateManager)
                };

                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                FileLogger.Log(ex.ToString());
            }
        }
    }
}
