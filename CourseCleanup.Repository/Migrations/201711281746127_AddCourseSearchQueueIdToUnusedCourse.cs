namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseSearchQueueIdToUnusedCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnusedCourse", "CourseSearchQueueId", c => c.Int(nullable: false));
            CreateIndex("dbo.UnusedCourse", "CourseSearchQueueId");
            AddForeignKey("dbo.UnusedCourse", "CourseSearchQueueId", "dbo.CourseSearchQueue", "Id", cascadeDelete: true);
            DropColumn("dbo.UnusedCourse", "ReportGeneratedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UnusedCourse", "ReportGeneratedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropForeignKey("dbo.UnusedCourse", "CourseSearchQueueId", "dbo.CourseSearchQueue");
            DropIndex("dbo.UnusedCourse", new[] { "CourseSearchQueueId" });
            DropColumn("dbo.UnusedCourse", "CourseSearchQueueId");
        }
    }
}
