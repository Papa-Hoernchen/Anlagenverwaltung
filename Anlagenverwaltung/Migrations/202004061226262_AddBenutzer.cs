namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBenutzer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Benutzers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalNr = c.String(),
                        Nachname = c.String(),
                        Vorname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Benutzers");
        }
    }
}
