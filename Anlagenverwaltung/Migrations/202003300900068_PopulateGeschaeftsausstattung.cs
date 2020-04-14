namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGeschaeftsausstattung : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (410061, 'Schreibtisch', '2008-12-03', 2302.65, 13)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (410067, 'Beamer Besprechungsraum', '2010-07-30', 890.71, 8)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (410076, 'PC Fr. Beine', '2011-10-06', 804.48, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
