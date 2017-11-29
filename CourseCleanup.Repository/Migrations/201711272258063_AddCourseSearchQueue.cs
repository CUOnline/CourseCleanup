namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseSearchQueue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseSearchQueue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTermId = c.String(),
                        EndTermId = c.String(),
                        Status = c.Int(nullable: false),
                        StatusMessage = c.String(),
                        SubmittedByEmail = c.String(),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseSearchQueue");
        }
    }
}
