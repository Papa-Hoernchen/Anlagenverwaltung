namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersNrToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Benutzers", "PersonalNr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Benutzers", "PersonalNr", c => c.String());
        }
    }
}
