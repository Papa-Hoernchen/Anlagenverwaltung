namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFestplatteIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes");
            DropIndex("dbo.FestplatteComputers", new[] { "Festplatte_Id" });
            DropPrimaryKey("dbo.Festplattes");
            DropPrimaryKey("dbo.FestplatteComputers");
            AlterColumn("dbo.Festplattes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FestplatteComputers", "Festplatte_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Festplattes", "Id");
            AddPrimaryKey("dbo.FestplatteComputers", new[] { "Festplatte_Id", "Computer_Id" });
            CreateIndex("dbo.FestplatteComputers", "Festplatte_Id");
            AddForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes");
            DropIndex("dbo.FestplatteComputers", new[] { "Festplatte_Id" });
            DropPrimaryKey("dbo.FestplatteComputers");
            DropPrimaryKey("dbo.Festplattes");
            AlterColumn("dbo.FestplatteComputers", "Festplatte_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Festplattes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.FestplatteComputers", new[] { "Festplatte_Id", "Computer_Id" });
            AddPrimaryKey("dbo.Festplattes", "Id");
            CreateIndex("dbo.FestplatteComputers", "Festplatte_Id");
            AddForeignKey("dbo.FestplatteComputers", "Festplatte_Id", "dbo.Festplattes", "Id", cascadeDelete: true);
        }
    }
}
