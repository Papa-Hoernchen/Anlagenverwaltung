namespace Anlagenverwaltung.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateFestplatte : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Festplattes " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Speicherkapazitaet, Schnittstelle)" +
                "VALUES (1, 'Seagate', 'ST2000DM008', 64.90, '2019-07-10', 'HDD', 2, 'SATA/600')");

            Sql("INSERT INTO Festplattes " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Speicherkapazitaet, Schnittstelle)" +
                "VALUES (2, 'Samsung', '970 EVO', 192.90, '2019-02-10', 'SSD', 1, 'M.2')");

            Sql("INSERT INTO Festplattes " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Speicherkapazitaet, Schnittstelle)" +
                "VALUES (3, 'WD', 'WD40EZRZ WD Blue', 97.90, '2019-04-12', 'HDD', 4, 'SATA/600')");

            Sql("INSERT INTO Festplattes " +
                "(Id, Hersteller, Produktbezeichnung, Einkaufspreis, Einkaufsdatum, Art, Speicherkapazitaet, Schnittstelle)" +
                "VALUES (4, 'Samsung', '860 EVO', 86.90, '2018-02-11', 'SSD', 1, 'SATA/600')");
        }
        
        public override void Down()
        {
        }
    }
}
