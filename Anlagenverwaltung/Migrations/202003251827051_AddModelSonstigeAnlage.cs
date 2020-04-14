namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelSonstigeAnlage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SonstigeAnlages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gegenstand = c.String(),
                        Bezeichnung = c.String(),
                        Einkaufspreis = c.Single(nullable: false),
                        Einkaufsdatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SonstigeAnlages");
        }
    }
}
