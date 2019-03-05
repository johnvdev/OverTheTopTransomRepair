namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revert : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FileModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
