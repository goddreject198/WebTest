namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "OriginalPrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "OriginalPrice2", c => c.Double(nullable: false));
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Double());
            AlterColumn("dbo.tb_Product", "Price", c => c.Double(nullable: false));
        }
    }
}
