namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildDeletedCourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeletedCourse", "CourseName", c => c.String());
            AddColumn("dbo.DeletedCourse", "CourseSISID", c => c.String());
            AddColumn("dbo.DeletedCourse", "CourseCode", c => c.String());
            AddColumn("dbo.DeletedCourse", "Term", c => c.String());
            AddColumn("dbo.DeletedCourse", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeletedCourse", "Status");
            DropColumn("dbo.DeletedCourse", "Term");
            DropColumn("dbo.DeletedCourse", "CourseCode");
            DropColumn("dbo.DeletedCourse", "CourseSISID");
            DropColumn("dbo.DeletedCourse", "CourseName");
        }
    }
}
