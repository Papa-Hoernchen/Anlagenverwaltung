namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEinkaufsdatumAndEinkaufspreisToSoftware : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anwendungssoftwares", "Einkaufspreis", c => c.Single(nullable: false));
            AddColumn("dbo.Anwendungssoftwares", "Einkaufsdatum", c => c.DateTime(nullable: false));
            AddColumn("dbo.Betriebssystems", "Einkaufspreis", c => c.Single(nullable: false));
            AddColumn("dbo.Betriebssystems", "Einkaufsdatum", c => c.DateTime(nullable: false));
            AddColumn("dbo.Unterstuetzungssoftwares", "Einkaufspreis", c => c.Single(nullable: false));
            AddColumn("dbo.Unterstuetzungssoftwares", "Einkaufsdatum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Unterstuetzungssoftwares", "Einkaufsdatum");
            DropColumn("dbo.Unterstuetzungssoftwares", "Einkaufspreis");
            DropColumn("dbo.Betriebssystems", "Einkaufsdatum");
            DropColumn("dbo.Betriebssystems", "Einkaufspreis");
            DropColumn("dbo.Anwendungssoftwares", "Einkaufsdatum");
            DropColumn("dbo.Anwendungssoftwares", "Einkaufspreis");
        }
    }
}
