namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "PriceSale", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "PriceSale");
        }
    }
}
