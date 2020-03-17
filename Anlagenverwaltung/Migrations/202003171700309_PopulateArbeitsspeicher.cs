namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateArbeitsspeicher : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Arbeitsspeichers " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Speicherkapazitaet, Taktfrequenz)" +
                "VALUES (1, 'Aegis', '', 67.00, '2019-05-05', 16, 3000)");

            Sql("INSERT INTO Arbeitsspeichers " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Speicherkapazitaet, Taktfrequenz)" +
                "VALUES (2, 'Vengeance', 'LPX LP', 83.80, '2019-10-11', 16, 3200)");

            Sql("INSERT INTO Arbeitsspeichers " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Speicherkapazitaet, Taktfrequenz)" +
                "VALUES (3, 'RipJaws', 'V', 75.00, '2020-01-06', 16, 3200)");

            Sql("INSERT INTO Arbeitsspeichers " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Speicherkapazitaet, Taktfrequenz)" +
                "VALUES (4, 'RipJaws', 'XH', 100.00, '2020-03-06', 16, 3200)");
        }
        
        public override void Down()
        {
        }
    }
}
