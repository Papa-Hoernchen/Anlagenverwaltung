namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateComputerAnwendungssoftwares : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (4, 2)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (1, 1)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (2, 3)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (5, 2)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (6, 3)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (7, 4)");

            Sql("INSERT INTO ComputerAnwendungssoftwares " +
                "(Computer_Id, Anwendungssoftware_Id)" +
                "VALUES (7, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
