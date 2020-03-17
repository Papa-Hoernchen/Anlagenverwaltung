namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMaus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Maus " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (1, 'HP', 'Z3700', 19.99, '2019-04-03', 'Funk')");

            Sql("INSERT INTO Maus " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (2, 'Logitech', 'MX Master', 69.99, '2020-02-02', 'Bluetooth')");

            Sql("INSERT INTO Maus " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (3, 'Logitech', 'M185', 3.99, '2018-06-10', 'Laser')");

            Sql("INSERT INTO Maus " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art)" +
                "VALUES (4, 'Cherry', '2310', 19.99, '2019-04-03', 'Laser')");
        }
        
        public override void Down()
        {
        }
    }
}
