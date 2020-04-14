namespace Anlagenverwaltung.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateProzessors : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Prozessors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Kerne, Taktfrequenz)" +
                "VALUES (1, 'AMD', 'Ryzen 5', 169.00, '2019-12-11', 6, 4.20)");

            Sql("INSERT INTO Prozessors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Kerne, Taktfrequenz)" +
                "VALUES (2, 'Intel', 'Core i9 9900', 459.21, '2019-03-03', 8, 3.10)");

            Sql("INSERT INTO Prozessors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Kerne, Taktfrequenz)" +
                "VALUES (3, 'Intel', ' Core i5 9400F', 146.00, '2019-03-02', 6, 2.90)");

            Sql("INSERT INTO Prozessors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Kerne, Taktfrequenz)" +
                "VALUES (4, 'AMD', ' Ryzen 9 3900X', 429.00, '2020-03-12', 12, 4.60)");
        }
        
        public override void Down()
        {
        }
    }
}
