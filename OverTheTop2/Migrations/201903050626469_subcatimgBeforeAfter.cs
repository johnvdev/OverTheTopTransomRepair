namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcatimgBeforeAfter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubCategories", "Afterimg_id", c => c.Int());
            AddColumn("dbo.SubCategories", "Beforeimg_id", c => c.Int());
            CreateIndex("dbo.SubCategories", "Afterimg_id");
            CreateIndex("dbo.SubCategories", "Beforeimg_id");
            AddForeignKey("dbo.SubCategories", "Afterimg_id", "dbo.SubCategoryImages", "id");
            AddForeignKey("dbo.SubCategories", "Beforeimg_id", "dbo.SubCategoryImages", "id");
            DropColumn("dbo.SubCategories", "Beforeimg");
            DropColumn("dbo.SubCategories", "Afterimg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCategories", "Afterimg", c => c.String());
            AddColumn("dbo.SubCategories", "Beforeimg", c => c.String());
            DropForeignKey("dbo.SubCategories", "Beforeimg_id", "dbo.SubCategoryImages");
            DropForeignKey("dbo.SubCategories", "Afterimg_id", "dbo.SubCategoryImages");
            DropIndex("dbo.SubCategories", new[] { "Beforeimg_id" });
            DropIndex("dbo.SubCategories", new[] { "Afterimg_id" });
            DropColumn("dbo.SubCategories", "Beforeimg_id");
            DropColumn("dbo.SubCategories", "Afterimg_id");
        }
    }
}
