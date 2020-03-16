namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoftwareModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anwendungssoftware",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Aufgabe = c.String(),
                        Name = c.String(),
                        Hersteller = c.String(),
                        Lizenznummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Systemsoftware",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Aufgabe = c.String(),
                        Name = c.String(),
                        Hersteller = c.String(),
                        Lizenznummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unterstuetzungssoftware",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Aufgabe = c.String(),
                        Name = c.String(),
                        Hersteller = c.String(),
                        Lizenznummer = c.String(),
                        Einkaufspreis = c.Double(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Unterstuetzungssoftware");
            DropTable("dbo.Systemsoftware");
            DropTable("dbo.Anwendungssoftware");
        }
    }
}
