namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTechnikUserToRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d11f57b-b4b7-4b09-b958-2635b329da70', N'525cbab5-4d73-4802-bd0a-1c8aeb8cdcdd')


");
        }
        
        public override void Down()
        {
        }
    }
}
