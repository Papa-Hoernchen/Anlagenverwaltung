namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSoftwareConstraints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerAnwendungssoftwares",
                c => new
                    {
                        Computer_Id = c.Int(nullable: false),
                        Anwendungssoftware_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Computer_Id, t.Anwendungssoftware_Id })
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Anwendungssoftwares", t => t.Anwendungssoftware_Id, cascadeDelete: true)
                .Index(t => t.Computer_Id)
                .Index(t => t.Anwendungssoftware_Id);
            
            CreateTable(
                "dbo.UnterstuetzungssoftwareComputers",
                c => new
                    {
                        Unterstuetzungssoftware_Id = c.Int(nullable: false),
                        Computer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Unterstuetzungssoftware_Id, t.Computer_Id })
                .ForeignKey("dbo.Unterstuetzungssoftwares", t => t.Unterstuetzungssoftware_Id, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .Index(t => t.Unterstuetzungssoftware_Id)
                .Index(t => t.Computer_Id);
            
            AddColumn("dbo.Computers", "BetriebssystemId", c => c.Int());
            CreateIndex("dbo.Computers", "BetriebssystemId");
            AddForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnterstuetzungssoftwareComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.UnterstuetzungssoftwareComputers", "Unterstuetzungssoftware_Id", "dbo.Unterstuetzungssoftwares");
            DropForeignKey("dbo.Computers", "BetriebssystemId", "dbo.Betriebssystems");
            DropForeignKey("dbo.ComputerAnwendungssoftwares", "Anwendungssoftware_Id", "dbo.Anwendungssoftwares");
            DropForeignKey("dbo.ComputerAnwendungssoftwares", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.UnterstuetzungssoftwareComputers", new[] { "Computer_Id" });
            DropIndex("dbo.UnterstuetzungssoftwareComputers", new[] { "Unterstuetzungssoftware_Id" });
            DropIndex("dbo.ComputerAnwendungssoftwares", new[] { "Anwendungssoftware_Id" });
            DropIndex("dbo.ComputerAnwendungssoftwares", new[] { "Computer_Id" });
            DropIndex("dbo.Computers", new[] { "BetriebssystemId" });
            DropColumn("dbo.Computers", "BetriebssystemId");
            DropTable("dbo.UnterstuetzungssoftwareComputers");
            DropTable("dbo.ComputerAnwendungssoftwares");
        }
    }
}
