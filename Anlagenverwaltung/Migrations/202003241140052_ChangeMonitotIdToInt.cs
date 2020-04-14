namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMonitotIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors");
            DropIndex("dbo.MonitorComputers", new[] { "Monitor_Id" });
            DropPrimaryKey("dbo.Monitors");
            DropPrimaryKey("dbo.MonitorComputers");
            AlterColumn("dbo.Monitors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MonitorComputers", "Monitor_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Monitors", "Id");
            AddPrimaryKey("dbo.MonitorComputers", new[] { "Monitor_Id", "Computer_Id" });
            CreateIndex("dbo.MonitorComputers", "Monitor_Id");
            AddForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors");
            DropIndex("dbo.MonitorComputers", new[] { "Monitor_Id" });
            DropPrimaryKey("dbo.MonitorComputers");
            DropPrimaryKey("dbo.Monitors");
            AlterColumn("dbo.MonitorComputers", "Monitor_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Monitors", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MonitorComputers", new[] { "Monitor_Id", "Computer_Id" });
            AddPrimaryKey("dbo.Monitors", "Id");
            CreateIndex("dbo.MonitorComputers", "Monitor_Id");
            AddForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors", "Id", cascadeDelete: true);
        }
    }
}
