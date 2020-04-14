namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBenutzerToComputer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "BenutzerId", c => c.Int());
            CreateIndex("dbo.Computers", "BenutzerId");
            AddForeignKey("dbo.Computers", "BenutzerId", "dbo.Benutzers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computers", "BenutzerId", "dbo.Benutzers");
            DropIndex("dbo.Computers", new[] { "BenutzerId" });
            DropColumn("dbo.Computers", "BenutzerId");
        }
    }
}
