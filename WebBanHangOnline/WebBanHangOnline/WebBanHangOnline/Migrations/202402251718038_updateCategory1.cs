namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Description", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Category", "Description", c => c.String());
        }
    }
}
