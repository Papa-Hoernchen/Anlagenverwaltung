namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBetriebssystem : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Betriebssystems " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Client', 'Microsoft', '10', 'XD877879')");

            Sql("INSERT INTO Betriebssystems " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Server', 'Microsoft', '7', 'jfwrfiren22')");

            Sql("INSERT INTO Betriebssystems " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Server', 'Microsoft', '10', 'sqwiksqws,')");

            Sql("INSERT INTO Betriebssystems " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Client', 'Linux', 'Debian', 'kxmqmxe')");

            Sql("INSERT INTO Betriebssystems " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Client', 'Linux', 'Ubuntu', 'powpkwsqk')");
        }
        
        public override void Down()
        {
        }
    }
}
