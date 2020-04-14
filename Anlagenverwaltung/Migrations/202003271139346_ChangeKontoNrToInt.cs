namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKontoNrToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kontoes", "Nummer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kontoes", "Nummer", c => c.Byte(nullable: false));
        }
    }
}
