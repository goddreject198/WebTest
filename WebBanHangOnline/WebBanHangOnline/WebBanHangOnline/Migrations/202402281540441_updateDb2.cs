namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Posts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Posts", "Image", c => c.String());
        }
    }
}
