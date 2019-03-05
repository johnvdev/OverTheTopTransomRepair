namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addparentField : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CategoryImages", name: "Category_id", newName: "Parent_id");
            RenameIndex(table: "dbo.CategoryImages", name: "IX_Category_id", newName: "IX_Parent_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CategoryImages", name: "IX_Parent_id", newName: "IX_Category_id");
            RenameColumn(table: "dbo.CategoryImages", name: "Parent_id", newName: "Category_id");
        }
    }
}
