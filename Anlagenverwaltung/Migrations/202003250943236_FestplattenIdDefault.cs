namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FestplattenIdDefault : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes");
            DropPrimaryKey("dbo.Festplattes");
            AlterColumn("dbo.Festplattes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Festplattes", "Id");
            AddForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes");
            DropPrimaryKey("dbo.Festplattes");
            AlterColumn("dbo.Festplattes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Festplattes", "Id");
            AddForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes", "Id", cascadeDelete: true);
        }
    }
}
