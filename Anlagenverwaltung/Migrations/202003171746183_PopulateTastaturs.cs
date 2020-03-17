namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTastaturs : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Tastaturs " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (1, 'Cherry', 'KC 1000', 11.49, '2018-10-11', 'Kabel')");

            Sql("INSERT INTO Tastaturs " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (2, 'Sharkoon', ' SKILLER MECH SGK3', 64.90, '2020-03-01', 'Kabel')");

            Sql("INSERT INTO Tastaturs " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (3, 'Acer', 'Predator Aethon 300', 49.90, '2019-04-10', 'Kabel')");

            Sql("INSERT INTO Tastaturs " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (4, 'Logitech', 'MX Keys Plus', 119.90, '2020-01-11', 'Funk')");
        }
        
        public override void Down()
        {
        }
    }
}
