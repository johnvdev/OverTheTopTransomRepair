namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subCAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryImagesId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "SubCategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SubCategoryId");
            DropColumn("dbo.Categories", "CategoryImagesId");
        }
    }
}
