namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePkw : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (320004, 'BMW 318i Cabrio gebr.', '2007-10-29', 16.395, 3)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (320005, 'Fiat Bravo gebr.', '2010-07-13', 9132.79, 3)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (320006, 'VW Golf Variant', '2011-11-24', 27635.33, 6)");
        }
        
        public override void Down()
        {
        }
    }
}
