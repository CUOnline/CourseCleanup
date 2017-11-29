using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseCleanup.Startup))]
namespace CourseCleanup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("CourseCleanupContext")
                                 .UseColouredConsoleLogProvider();

            app.UseHangfireServer(new BackgroundJobServerOptions()
            {
                WorkerCount = 1 // Single worker
            });
        }
    }
}
