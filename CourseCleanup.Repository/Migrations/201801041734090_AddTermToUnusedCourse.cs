namespace CourseCleanup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTermToUnusedCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnusedCourse", "TermId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnusedCourse", "TermId");
        }
    }
}
