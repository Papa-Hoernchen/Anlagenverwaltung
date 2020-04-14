namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnterstuetzungssoftwares : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Unterstuetzungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('DBMS', 'Microsoft', 'SQL Server Studio', '5651163')");

            Sql("INSERT INTO Unterstuetzungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Texteditor', 'Microsoft', 'Notepad++', '15521561')");

            Sql("INSERT INTO Unterstuetzungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('Vierenscanner', 'Kaspersky', 'Endpoint', '551615')");

            Sql("INSERT INTO Unterstuetzungssoftwares " +
                "(Art, Hersteller, Bezeichnung, Lizenznummer)" +
                "VALUES ('IDE', 'Embarcadero', 'Delphi', '414515')");
        }
        
        public override void Down()
        {
        }
    }
}
