namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseIdToUnusedCourses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnusedCourse", "CourseId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnusedCourse", "CourseId");
        }
    }
}
