namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSoftwareModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anwendungssoftwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Art = c.String(),
                        Hersteller = c.String(),
                        Bezeichnung = c.String(),
                        Lizenznummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Betriebssystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Art = c.String(),
                        Hersteller = c.String(),
                        Bezeichnung = c.String(),
                        Lizenznummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unterstuetzungssoftwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Art = c.String(),
                        Hersteller = c.String(),
                        Bezeichnung = c.String(),
                        Lizenznummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Unterstuetzungssoftwares");
            DropTable("dbo.Betriebssystems");
            DropTable("dbo.Anwendungssoftwares");
        }
    }
}
