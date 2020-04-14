namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonitorenIdDefault : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors");
            DropPrimaryKey("dbo.Monitors");
            AlterColumn("dbo.Monitors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Monitors", "Id");
            AddForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors");
            DropPrimaryKey("dbo.Monitors");
            AlterColumn("dbo.Monitors", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Monitors", "Id");
            AddForeignKey("dbo.MonitorComputers", "Monitor_Id", "dbo.Monitors", "Id", cascadeDelete: true);
        }
    }
}
