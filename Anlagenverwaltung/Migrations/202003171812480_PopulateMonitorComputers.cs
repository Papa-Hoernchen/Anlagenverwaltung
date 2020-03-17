namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMonitorComputers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MonitorComputers " +
                "(Monitor_Id, Computer_Id)" +
                "VALUES (1, 2)");

            Sql("INSERT INTO MonitorComputers " +
                "(Monitor_Id, Computer_Id)" +
                "VALUES (2, 3)");

            Sql("INSERT INTO MonitorComputers " +
                "(Monitor_Id, Computer_Id)" +
                "VALUES (4, 1)");

            Sql("INSERT INTO MonitorComputers " +
                "(Monitor_Id, Computer_Id)" +
                "VALUES (3, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
