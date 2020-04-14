namespace Anlagenverwaltung.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateFestplatteComputer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO FestplatteComputers " +
                "(Festplatte_Id, Computer_Id)" +
                "VALUES (2, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
