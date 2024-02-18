namespace WebAppLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(),
                        CourseContent = c.String(),
                        CourseDate = c.DateTime(nullable: false),
                        CourseDuration = c.String(),
                        CourseImage = c.String(),
                        FieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "FieldId", "dbo.Fields");
            DropIndex("dbo.Courses", new[] { "FieldId" });
            DropTable("dbo.Courses");
        }
    }
}
