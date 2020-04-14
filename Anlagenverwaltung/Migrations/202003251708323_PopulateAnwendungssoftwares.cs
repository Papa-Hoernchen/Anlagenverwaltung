namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAnwendungssoftwares : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Anwendungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Textverarbeitung', 'Microsoft', 'Word', 'dkwmewdö')");

            Sql("INSERT INTO Anwendungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Textverarbeitung', 'Apache', 'Open Office', '5156161')");

            Sql("INSERT INTO Anwendungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Kalkulation', 'Microsoft', 'Excel', 'ggfggf')");

            Sql("INSERT INTO Anwendungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Buchungen', 'Datev', 'Writer', '51151')");
        }
        
        public override void Down()
        {
        }
    }
}
