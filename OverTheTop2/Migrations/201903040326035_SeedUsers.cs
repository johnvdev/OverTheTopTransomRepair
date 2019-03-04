namespace OverTheTop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
               
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2067f50-8426-41ae-8a6e-b8a23af0f56a', N'admin@email.com', 0, N'ACuJh0w2GSWFnRh0kyWy8FcUoJKXb9bs0kDxsudqd81cSRE0ij35tlodIUqxfZhhyg==', N'8254783f-6802-475d-bd63-9aff35302d62', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5d01763f-8002-4aa9-b170-f4c2e250c6db', N'Admin')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a2067f50-8426-41ae-8a6e-b8a23af0f56a', N'5d01763f-8002-4aa9-b170-f4c2e250c6db')

");
        }
        
        public override void Down()
        {
        }
    }
}
