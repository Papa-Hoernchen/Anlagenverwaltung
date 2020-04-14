namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAbschreibungModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abschreibungs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KontoNr = c.Int(nullable: false),
                        Name = c.String(),
                        Anschaffungsdatum = c.DateTime(nullable: false),
                        Anschaffungskosten = c.Single(nullable: false),
                        Nutzungsdauer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abschreibungs");
        }
    }
}
