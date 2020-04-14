namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingKontoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kontoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nummer = c.Byte(nullable: false),
                        Bezeichnung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Anwendungssoftwares", "KontoId", c => c.Int());
            AddColumn("dbo.Computers", "KontoId", c => c.Int());
            AddColumn("dbo.Betriebssystems", "KontoId", c => c.Int());
            AddColumn("dbo.Unterstuetzungssoftwares", "KontoId", c => c.Int());
            AddColumn("dbo.SonstigeAnlages", "KontoId", c => c.Int());
            CreateIndex("dbo.Anwendungssoftwares", "KontoId");
            CreateIndex("dbo.Computers", "KontoId");
            CreateIndex("dbo.Betriebssystems", "KontoId");
            CreateIndex("dbo.Unterstuetzungssoftwares", "KontoId");
            CreateIndex("dbo.SonstigeAnlages", "KontoId");
            AddForeignKey("dbo.Betriebssystems", "KontoId", "dbo.Kontoes", "Id");
            AddForeignKey("dbo.Computers", "KontoId", "dbo.Kontoes", "Id");
            AddForeignKey("dbo.Unterstuetzungssoftwares", "KontoId", "dbo.Kontoes", "Id");
            AddForeignKey("dbo.Anwendungssoftwares", "KontoId", "dbo.Kontoes", "Id");
            AddForeignKey("dbo.SonstigeAnlages", "KontoId", "dbo.Kontoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SonstigeAnlages", "KontoId", "dbo.Kontoes");
            DropForeignKey("dbo.Anwendungssoftwares", "KontoId", "dbo.Kontoes");
            DropForeignKey("dbo.Unterstuetzungssoftwares", "KontoId", "dbo.Kontoes");
            DropForeignKey("dbo.Computers", "KontoId", "dbo.Kontoes");
            DropForeignKey("dbo.Betriebssystems", "KontoId", "dbo.Kontoes");
            DropIndex("dbo.SonstigeAnlages", new[] { "KontoId" });
            DropIndex("dbo.Unterstuetzungssoftwares", new[] { "KontoId" });
            DropIndex("dbo.Betriebssystems", new[] { "KontoId" });
            DropIndex("dbo.Computers", new[] { "KontoId" });
            DropIndex("dbo.Anwendungssoftwares", new[] { "KontoId" });
            DropColumn("dbo.SonstigeAnlages", "KontoId");
            DropColumn("dbo.Unterstuetzungssoftwares", "KontoId");
            DropColumn("dbo.Betriebssystems", "KontoId");
            DropColumn("dbo.Computers", "KontoId");
            DropColumn("dbo.Anwendungssoftwares", "KontoId");
            DropTable("dbo.Kontoes");
        }
    }
}
