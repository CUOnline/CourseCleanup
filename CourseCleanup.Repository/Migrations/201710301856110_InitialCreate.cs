namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnusedCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportGeneratedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CourseName = c.String(),
                        CourseSISID = c.String(),
                        CourseCode = c.String(),
                        Term = c.String(),
                        Status = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnusedCourse");
        }
    }
}
