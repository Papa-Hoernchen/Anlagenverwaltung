namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSonstigeAnlagen : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SonstigeAnlages " +
                "(Gegenstand, Bezeichnung, Einkaufspreis, Einkaufsdatum)" +
                "VALUES ('Tisch', 'Arbeitsplatz', 30.00, '2019-06-08')");

            Sql("INSERT INTO SonstigeAnlages " +
                "(Gegenstand, Bezeichnung, Einkaufspreis, Einkaufsdatum)" +
                "VALUES ('Kaffeemaschine', 'Automatik', 600.00, '2018-06-08')");

            Sql("INSERT INTO SonstigeAnlages " +
                "(Gegenstand, Bezeichnung, Einkaufspreis, Einkaufsdatum)" +
                "VALUES ('Auto', 'Audi A3', 20000.00, '2019-03-06')");

            Sql("INSERT INTO SonstigeAnlages " +
                "(Gegenstand, Bezeichnung, Einkaufspreis, Einkaufsdatum)" +
                "VALUES ('Stuhl', 'Buerositz', 40.00, '2018-03-01')");
        }
        
        public override void Down()
        {
        }
    }
}
