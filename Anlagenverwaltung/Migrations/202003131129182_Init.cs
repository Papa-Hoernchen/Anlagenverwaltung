namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                        Festplatte_Id = c.Int(nullable: false),
                        Computer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Festplatte_Id, t.Computer_Id })
                .ForeignKey("dbo.Festplatte", t => t.Festplatte_Id)
                .ForeignKey("dbo.Computer", t => t.Computer_Id)
                .Index(t => t.Festplatte_Id)
                .Index(t => t.Computer_Id);
            
            CreateTable(
                "dbo.MonitorComputers",
                c => new
                    {
                        Monitor_Id = c.Int(nullable: false),
                        Computer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Monitor_Id, t.Computer_Id })
                .ForeignKey("dbo.Monitor", t => t.Monitor_Id)
                .ForeignKey("dbo.Computer", t => t.Computer_Id)
                .Index(t => t.Monitor_Id)
                .Index(t => t.Computer_Id);
            
            CreateTable(
                "dbo.Arbeitsspeicher",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Speicherkapazitaet = c.Int(nullable: false),
                        Taktfrequenz = c.Single(nullable: false),
                        Datenuebrtragungsrate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Computer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Arbeitsspeicher_Id = c.Int(),
                        Maus_Id = c.Int(),
                        Prozessor_Id = c.Int(),
                        Tastatur_Id = c.Int(),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        ArbeitsspeicherId = c.Byte(nullable: false),
                        ProzessorId = c.Byte(nullable: false),
                        MausId = c.Byte(nullable: false),
                        TastaturId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arbeitsspeicher", t => t.Arbeitsspeicher_Id)
                .ForeignKey("dbo.Maus", t => t.Maus_Id)
                .ForeignKey("dbo.Prozessor", t => t.Prozessor_Id)
                .ForeignKey("dbo.Tastatur", t => t.Tastatur_Id)
                .Index(t => t.Arbeitsspeicher_Id)
                .Index(t => t.Maus_Id)
                .Index(t => t.Prozessor_Id)
                .Index(t => t.Tastatur_Id);
            
            CreateTable(
                "dbo.Festplatte",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
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
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monitor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                        Zoll = c.Single(nullable: false),
                        Pixel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prozessor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Kerne = c.Int(nullable: false),
                        Taktfrequenz = c.Single(nullable: false),
                        Uebertragungsrate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tastatur",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Produktname = c.String(),
                        Produktnummer = c.String(),
                        Modellnummer = c.String(),
                        Seriennummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Art = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computer", "Tastatur_Id", "dbo.Tastatur");
            DropForeignKey("dbo.Computer", "Prozessor_Id", "dbo.Prozessor");
            DropForeignKey("dbo.Computer", "Maus_Id", "dbo.Maus");
            DropForeignKey("dbo.Computer", "Arbeitsspeicher_Id", "dbo.Arbeitsspeicher");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computer");
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitor");
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computer");
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplatte");
            DropIndex("dbo.Computer", new[] { "Tastatur_Id" });
            DropIndex("dbo.Computer", new[] { "Prozessor_Id" });
            DropIndex("dbo.Computer", new[] { "Maus_Id" });
            DropIndex("dbo.Computer", new[] { "Arbeitsspeicher_Id" });
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
            DropTable("dbo.Tastatur");
            DropTable("dbo.Prozessor");
            DropTable("dbo.Monitor");
            DropTable("dbo.Maus");
            DropTable("dbo.Festplatte");
            DropTable("dbo.Computer");
            DropTable("dbo.Arbeitsspeicher");
            DropTable("dbo.MonitorComputers");
            DropTable("dbo.FestplatteComputers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
