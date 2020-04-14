namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAbschreibung : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (27032, 'Team Viewer Update', '2013-01-18', 645, 3)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (27030, 'Visual Studio Prof. 2010', '2012-03-02', 797.48, 3)");

            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (27035, 'Fastspring Addict Lizenz', '2013-06-06', 684.08, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
