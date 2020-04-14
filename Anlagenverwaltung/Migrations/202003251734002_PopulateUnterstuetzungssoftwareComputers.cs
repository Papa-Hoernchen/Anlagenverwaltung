namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnterstuetzungssoftwareComputers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (1, 1)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (2, 2)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (3, 4)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (4, 5)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (2, 6)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (3, 7)");

            Sql("INSERT INTO UnterstuetzungssoftwareComputers " +
                "(Unterstuetzungssoftware_Id, Computer_Id)" +
                "VALUES (1, 8)");
        }
        
        public override void Down()
        {
        }
    }
}
