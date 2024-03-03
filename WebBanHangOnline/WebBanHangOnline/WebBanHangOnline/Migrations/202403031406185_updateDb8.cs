namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Double(nullable: false));
        }
    }
}
