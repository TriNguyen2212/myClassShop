namespace MyClassShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.Products", "CraetedDate");
            DropColumn("dbo.ProductCategories", "CraetedDate");
            DropColumn("dbo.PostCategories", "CraetedDate");
            DropColumn("dbo.Posts", "CraetedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CraetedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CraetedDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CraetedDate", c => c.DateTime());
            AddColumn("dbo.Products", "CraetedDate", c => c.DateTime());
            DropColumn("dbo.Posts", "CreatedDate");
            DropColumn("dbo.PostCategories", "CreatedDate");
            DropColumn("dbo.ProductCategories", "CreatedDate");
            DropColumn("dbo.Products", "CreatedDate");
            DropTable("dbo.Errors");
        }
    }
}
