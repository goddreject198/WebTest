namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThongKes", "ThoiGian", c => c.DateTime(nullable: false));
            DropColumn("dbo.ThongKes", "ThoiGiaan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ThongKes", "ThoiGiaan", c => c.DateTime(nullable: false));
            DropColumn("dbo.ThongKes", "ThoiGian");
        }
    }
}
