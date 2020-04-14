namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputerBetriebssystemIdNotNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems");
            DropIndex("dbo.Computers", new[] { "BetriebssystemId" });
            AlterColumn("dbo.Computers", "BetriebssystemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Computers", "BetriebssystemId");
            AddForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems");
            DropIndex("dbo.Computers", new[] { "BetriebssystemId" });
            AlterColumn("dbo.Computers", "BetriebssystemId", c => c.Int());
            CreateIndex("dbo.Computers", "BetriebssystemId");
            AddForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems", "Id");
        }
    }
}
