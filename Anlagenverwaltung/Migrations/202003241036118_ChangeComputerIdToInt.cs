namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeComputerIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.FestplatteComputers", new[] { "Computer_Id" });
            DropIndex("dbo.MonitorComputers", new[] { "Computer_Id" });
            DropPrimaryKey("dbo.Computers");
            DropPrimaryKey("dbo.FestplatteComputers");
            DropPrimaryKey("dbo.MonitorComputers");
            AlterColumn("dbo.Computers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FestplatteComputers", "Computer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MonitorComputers", "Computer_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Computers", "Id");
            AddPrimaryKey("dbo.FestplatteComputers", new[] { "Festplatte_Id", "Computer_Id" });
            AddPrimaryKey("dbo.MonitorComputers", new[] { "Monitor_Id", "Computer_Id" });
            CreateIndex("dbo.FestplatteComputers", "Computer_Id");
            CreateIndex("dbo.MonitorComputers", "Computer_Id");
            AddForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.MonitorComputers", new[] { "Computer_Id" });
            DropIndex("dbo.FestplatteComputers", new[] { "Computer_Id" });
            DropPrimaryKey("dbo.MonitorComputers");
            DropPrimaryKey("dbo.FestplatteComputers");
            DropPrimaryKey("dbo.Computers");
            AlterColumn("dbo.MonitorComputers", "Computer_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.FestplatteComputers", "Computer_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Computers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MonitorComputers", new[] { "Monitor_Id", "Computer_Id" });
            AddPrimaryKey("dbo.FestplatteComputers", new[] { "Festplatte_Id", "Computer_Id" });
            AddPrimaryKey("dbo.Computers", "Id");
            CreateIndex("dbo.MonitorComputers", "Computer_Id");
            CreateIndex("dbo.FestplatteComputers", "Computer_Id");
            AddForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
        }
    }
}
