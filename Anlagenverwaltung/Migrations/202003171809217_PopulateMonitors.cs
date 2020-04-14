namespace Anlagenverwaltung.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMonitors : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Monitors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Zoll, Pixel)" +
                "VALUES (1, 'ASUS', 'x3 VG279Q', 282.00, '2019-04-05', 'Gaming', 27, '1920x1080')");

            Sql("INSERT INTO Monitors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Zoll, Pixel)" +
                "VALUES (2, 'Acer', 'GH GH9287X', 150.00, '2019-01-08', '', 27, '1920x1080')");

            Sql("INSERT INTO Monitors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Zoll, Pixel)" +
                "VALUES (3, 'Samsung', 'GH XH4521', 88.00, '2019-10-08', '', 27, '1920x1080')");

            Sql("INSERT INTO Monitors " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Zoll, Pixel)" +
                "VALUES (4, 'BenQ', 'O265768', 133.00, '2018-07-08', '', 27, '2400x2100')");
        }
        
        public override void Down()
        {
        }
    }
}
