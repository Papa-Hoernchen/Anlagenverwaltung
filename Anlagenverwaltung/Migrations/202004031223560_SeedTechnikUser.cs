namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTechnikUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'525cbab5-4d73-4802-bd0a-1c8aeb8cdcdd', N'CanUseVerwaltung')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d11f57b-b4b7-4b09-b958-2635b329da70', N'technik@gis.com', 0, N'ABbHH23/FHC8QGiJ+kjyCcclsXz/OdwjXw96/zaivDLwZR3uiuw6KLjQIu4we0+U9g==', N'1322ed7d-9d60-40b9-b218-0fe15f32ea50', NULL, 0, 0, NULL, 1, 0, N'technik@gis.com')
");
        }
        
        public override void Down()
        {
        }
    }
}
