namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNutzungsdauerToSonstigeAnlagen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SonstigeAnlages", "Nutzungsdauer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SonstigeAnlages", "Nutzungsdauer");
        }
    }
}
