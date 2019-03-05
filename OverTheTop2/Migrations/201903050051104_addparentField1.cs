namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addparentField1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileModels");
        }
    }
}
