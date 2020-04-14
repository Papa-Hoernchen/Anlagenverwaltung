namespace Anlagenverwaltung.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        MacAdresse = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        ArbeitsspeicherId = c.Byte(nullable: false),
                        ProzessorId = c.Byte(nullable: false),
                        MausId = c.Byte(nullable: false),
                        TastaturId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arbeitsspeichers", t => t.ArbeitsspeicherId, cascadeDelete: true)
                .ForeignKey("dbo.Maus", t => t.MausId, cascadeDelete: true)
                .ForeignKey("dbo.Prozessors", t => t.ProzessorId, cascadeDelete: true)
                .ForeignKey("dbo.Tastaturs", t => t.TastaturId, cascadeDelete: true)
                .Index(t => t.ArbeitsspeicherId)
                .Index(t => t.ProzessorId)
                .Index(t => t.MausId)
                .Index(t => t.TastaturId);
            
            CreateTable(
                "dbo.Arbeitsspeichers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Speicherkapazitaet = c.Int(nullable: false),
                        Taktfrequenz = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Festplattes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                        Speicherkapazitaet = c.Int(nullable: false),
                        Schnittstelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                        Zoll = c.Single(nullable: false),
                        Pixel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prozessors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Kerne = c.Int(nullable: false),
                        Taktfrequenz = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tastaturs",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Hersteller = c.String(),
                        Produktbezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FestplatteComputers",
                c => new
                    {
                        Festplatte_Id = c.Byte(nullable: false),
                        Computer_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Festplatte_Id, t.Computer_Id })
                .ForeignKey("dbo.Festplattes", t => t.Festplatte_Id, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .Index(t => t.Festplatte_Id)
                .Index(t => t.Computer_Id);
            
            CreateTable(
                "dbo.MonitorComputers",
                c => new
                    {
                        Monitor_Id = c.Byte(nullable: false),
                        Computer_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Monitor_Id, t.Computer_Id })
                .ForeignKey("dbo.Monitors", t => t.Monitor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .Index(t => t.Monitor_Id)
                .Index(t => t.Computer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Computers", "TastaturId", "dbo.Tastaturs");
            DropForeignKey("dbo.Computers", "ProzessorId", "dbo.Prozessors");
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors");
            DropForeignKey("dbo.Computers", "MausId", "dbo.Maus");
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes");
            DropForeignKey("dbo.Computers", "ArbeitsspeicherId", "dbo.Arbeitsspeichers");
            DropIndex("dbo.MonitorComputers", new[] { "Computer_Id" });
            DropIndex("dbo.MonitorComputers", new[] { "Monitor_Id" });
            DropIndex("dbo.FestplatteComputers", new[] { "Computer_Id" });
            DropIndex("dbo.FestplatteComputers", new[] { "Festplatte_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Computers", new[] { "TastaturId" });
            DropIndex("dbo.Computers", new[] { "MausId" });
            DropIndex("dbo.Computers", new[] { "ProzessorId" });
            DropIndex("dbo.Computers", new[] { "ArbeitsspeicherId" });
            DropTable("dbo.MonitorComputers");
            DropTable("dbo.FestplatteComputers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tastaturs");
            DropTable("dbo.Prozessors");
            DropTable("dbo.Monitors");
            DropTable("dbo.Maus");
            DropTable("dbo.Festplattes");
            DropTable("dbo.Arbeitsspeichers");
            DropTable("dbo.Computers");
        }
    }
}
