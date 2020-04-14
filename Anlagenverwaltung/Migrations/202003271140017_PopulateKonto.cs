namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateKonto : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Kontoes " +
                "(Nummer, Bezeichnung)" +
                "VALUES (410, 'Gesch�ftsausstattung')");

            Sql("INSERT INTO Kontoes " +
                "(Nummer, Bezeichnung)" +
                "VALUES (27, 'EDV-Software')");

            Sql("INSERT INTO Kontoes " +
                "(Nummer, Bezeichnung)" +
                "VALUES (420, 'B�roeinrichtung')");

            Sql("INSERT INTO Kontoes " +
                "(Nummer, Bezeichnung)" +
                "VALUES (320, 'Pkw')");

            Sql("INSERT INTO Kontoes " +
                "(Nummer, Bezeichnung)" +
                "VALUES (500, 'Anteil AO')");
        }
        
        public override void Down()
        {
        }
    }
}
