namespace CourseCleanup.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CUOCourseCleanupServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.InstallerCUOInactiveCourseDelete = new System.ServiceProcess.ServiceInstaller();
            this.InstallerUnusedCourseSearch = new System.ServiceProcess.ServiceInstaller();
            // 
            // CUOCourseCleanupServiceProcessInstaller
            // 
            this.CUOCourseCleanupServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.CUOCourseCleanupServiceProcessInstaller.Password = null;
            this.CUOCourseCleanupServiceProcessInstaller.Username = null;
            // 
            // InstallerCUOInactiveCourseDelete
            // 
            this.InstallerCUOInactiveCourseDelete.Description = "Service to process course deletion for inactive courses for the CourseCleanup Web" +
    " App";
            this.InstallerCUOInactiveCourseDelete.DisplayName = "CUOInactiveCourseDelete";
            this.InstallerCUOInactiveCourseDelete.ServiceName = "CUOInactiveCourseDelete";
            this.InstallerCUOInactiveCourseDelete.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // InstallerUnusedCourseSearch
            // 
            this.InstallerUnusedCourseSearch.Description = "Service to process searches for inactive courses for the CourseCleanup Web App";
            this.InstallerUnusedCourseSearch.DisplayName = "CUOInactiveCourseSearch";
            this.InstallerUnusedCourseSearch.ServiceName = "CUOInactiveCourseSearch";
            this.InstallerUnusedCourseSearch.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.CUOCourseCleanupServiceProcessInstaller,
            this.InstallerCUOInactiveCourseDelete,
            this.InstallerUnusedCourseSearch});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller CUOCourseCleanupServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller InstallerCUOInactiveCourseDelete;
        private System.ServiceProcess.ServiceInstaller InstallerUnusedCourseSearch;
    }
}