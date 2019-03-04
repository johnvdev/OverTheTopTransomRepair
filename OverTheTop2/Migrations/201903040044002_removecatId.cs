namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecatId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryImagesId");
            DropColumn("dbo.Categories", "SubCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "SubCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryImagesId", c => c.Int(nullable: false));
        }
    }
}
