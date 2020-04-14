namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43e462aa-4ee4-4197-90f0-e50a5cf57dab', N'gast@gis.com', 0, N'AI6W3kq/v69scsJGs/mXy6mWx6AFTIVi0X3bN8LUz20R9ojWhYm3kNnGe81jFRWkVQ==', N'487f9ad4-b420-4f35-982c-413959ea613b', NULL, 0, 0, NULL, 1, 0, N'gast@gis.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'88563723-c524-461e-99a9-0a398b3fac6c', N'wiens1612@gmx.de', 0, N'AJWjcGfXO8kxvK9BQl/Vwfn23w/b4CB5l+i9+q9cEasN7H8g9vAUmtJyrvJKPPLkhQ==', N'ddc71b22-69aa-4600-acf2-5f178ec7319b', NULL, 0, 0, NULL, 1, 0, N'wiens1612@gmx.de')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d8776ea-fbc9-446c-9c78-85e552d35b5a', N'admin@gis.com', 0, N'AFmbcq595qCragAqG5wbmaJVA41KfE2hDAPTednV010fNKHHIxwgXWW0SXjRLrOJtg==', N'16f93a91-307a-4877-b57b-5a4feabb5bfa', NULL, 0, 0, NULL, 1, 0, N'admin@gis.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0a367561-90f6-44b6-825c-acafd9bed73e', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d8776ea-fbc9-446c-9c78-85e552d35b5a', N'0a367561-90f6-44b6-825c-acafd9bed73e')

");

        }

    public override void Down()
        {
        }
    }
}
