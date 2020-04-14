namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputerHerstellerRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computers", "Hersteller", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Computers", "Hersteller", c => c.String());
        }
    }
}
