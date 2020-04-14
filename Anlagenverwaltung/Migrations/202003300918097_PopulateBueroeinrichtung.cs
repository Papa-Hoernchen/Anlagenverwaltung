namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBueroeinrichtung : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (420015, 'Spülmaschine', '2005-11-17', 551.72, 10)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (420022, 'Kühlschrank', '2005-12-15', 477, 10)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (420028, 'Schrankwand Erdgeschoss', '2007-12-27', 5280, 13)");
        }
        
        public override void Down()
        {
        }
    }
}
