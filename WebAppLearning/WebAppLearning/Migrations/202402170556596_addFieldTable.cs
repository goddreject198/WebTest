namespace WebAppLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(nullable: false),
                        FieldDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fields");
        }
    }
}
