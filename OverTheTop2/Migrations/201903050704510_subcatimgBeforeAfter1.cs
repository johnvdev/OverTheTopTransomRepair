namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcatimgBeforeAfter1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "Afterimg_id", "dbo.SubCategoryImages");
            DropForeignKey("dbo.SubCategories", "Beforeimg_id", "dbo.SubCategoryImages");
            DropIndex("dbo.SubCategories", new[] { "Afterimg_id" });
            DropIndex("dbo.SubCategories", new[] { "Beforeimg_id" });
            AddColumn("dbo.SubCategories", "Beforeimg", c => c.String());
            AddColumn("dbo.SubCategories", "Afterimg", c => c.String());
            DropColumn("dbo.SubCategories", "Afterimg_id");
            DropColumn("dbo.SubCategories", "Beforeimg_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCategories", "Beforeimg_id", c => c.Int());
            AddColumn("dbo.SubCategories", "Afterimg_id", c => c.Int());
            DropColumn("dbo.SubCategories", "Afterimg");
            DropColumn("dbo.SubCategories", "Beforeimg");
            CreateIndex("dbo.SubCategories", "Beforeimg_id");
            CreateIndex("dbo.SubCategories", "Afterimg_id");
            AddForeignKey("dbo.SubCategories", "Beforeimg_id", "dbo.SubCategoryImages", "id");
            AddForeignKey("dbo.SubCategories", "Afterimg_id", "dbo.SubCategoryImages", "id");
        }
    }
}
