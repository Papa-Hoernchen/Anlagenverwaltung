namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAnteilAO : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Abschreibungs " +
                "(KontoNr, Name, Anschaffungsdatum, Anschaffungskosten, Nutzungsdauer)" +
                "VALUES (500001, 'Beteiligung AO', '2005-04-18', 8306.19, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
