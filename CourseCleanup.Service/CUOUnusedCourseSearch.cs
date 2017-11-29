using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Configuration;

namespace CourseCleanup.Service
{
    partial class CUOUnusedCourseSearch : ServiceBase
    {
        private readonly Timer timer = new Timer();
        private IUnusedCourseSearchManager inactiveCourseSearchManager;

        public CUOUnusedCourseSearch(IUnusedCourseSearchManager inactiveCourseSearchManager)
        {
            InitializeComponent();
            this.inactiveCourseSearchManager = inactiveCourseSearchManager;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                var interval = string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["PollingInterval"]) ? 60000
                    : Convert.ToDouble(ConfigurationManager.AppSettings["PollingInterval"]);

                timer.Interval = interval;
                timer.Elapsed += TimerElapsed;
                timer.Enabled = true;
                timer.Start();
            }
            catch (Exception e)
            {
                FileLogger.Log("OnStart :: " + e.ToString());
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                RunSearches();
            }
            catch (Exception ex)
            {
                FileLogger.Log("TimerElapsed :: " + ex.ToString());
            }
        }

        private void RunSearches()
        {
            try
            {
                timer.Stop();
                inactiveCourseSearchManager.RunQueuedSearchesAsync();
            }
            catch (Exception ex)
            {
                FileLogger.Log("RunSearches :: " + ex.ToString());
                throw;
            }
            finally
            {
                timer.Start();
            }
        }

        protected override void OnStop()
        {
            try
            {
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
            catch (Exception e)
            {
                FileLogger.Log("OnStop :: " + e.ToString());
            }
        }
    }
}
