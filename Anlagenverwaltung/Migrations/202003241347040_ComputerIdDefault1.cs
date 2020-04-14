namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputerIdDefault1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers");
            DropPrimaryKey("dbo.Computers");
            AlterColumn("dbo.Computers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Computers", "Id");
            AddForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers");
            DropPrimaryKey("dbo.Computers");
            AlterColumn("dbo.Computers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Computers", "Id");
            AddForeignKey("dbo.MonitorComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FestplatteComputers", "Computer_Id", "dbo.Computers", "Id", cascadeDelete: true);
        }
    }
}
